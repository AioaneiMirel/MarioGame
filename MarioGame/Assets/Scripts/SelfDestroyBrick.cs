namespace Assets.Scripts
{
    using System;

    using UnityEngine;

    public class SelfDestroyBrick : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                foreach (var contact in col.contacts)
                {
                    Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
                    if (contact.normal.y == 1)
                    {
                        Invoke("DestroyMe", 2);
                    }
                }
            }
        }

        void DestroyMe()
        {
            Destroy(gameObject);
        }
    }
}