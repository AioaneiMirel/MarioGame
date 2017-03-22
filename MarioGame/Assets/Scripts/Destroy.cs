using UnityEngine;

namespace Assets.Scripts
{
    public class Destroy : MonoBehaviour
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
            Debug.Log("am intrat");

            if (col.gameObject.name == "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}