namespace Assets.Scripts
{
    using System;

    using UnityEngine;

    public class SelfDestroyBrick : MonoBehaviour
    {
        private Rigidbody body;

        private BoxCollider collider;
        // Use this for initialization
        void Start()
        {
            body = GetComponent<Rigidbody>();
            collider = GetComponent<BoxCollider>();
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
                        body.constraints = RigidbodyConstraints.None;
                        body.AddForce(0,3,3,ForceMode.Impulse);
                        body.AddTorque(0, 3, 3, ForceMode.Impulse);
                        collider.enabled = false;
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