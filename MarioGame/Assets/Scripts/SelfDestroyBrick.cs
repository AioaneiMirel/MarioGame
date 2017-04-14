namespace Assets.Scripts
{
    using UnityEngine;

    public class SelfDestroyBrick : MonoBehaviour
    {
        private Rigidbody body;

        private BoxCollider _collider;

        // Use this for initialization
        void Start()
        {
            body = GetComponent<Rigidbody>();
            _collider = GetComponent<BoxCollider>();
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
                        gameObject.GetComponent<Rigidbody>().useGravity = true;
                        body.constraints = RigidbodyConstraints.None;
                        body.AddForce(0, 3, 3, ForceMode.Impulse);
                        body.AddTorque(0, 3, 3, ForceMode.Impulse);
                        _collider.enabled = false;
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