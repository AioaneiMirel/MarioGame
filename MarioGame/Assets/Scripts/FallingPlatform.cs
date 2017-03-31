namespace Assets.Scripts
{
    using UnityEngine;

    public class FallingPlatform : MonoBehaviour
    {
        public float TimeBeforeFall;

        private Rigidbody _rigidbody;

        // Use this for initialization
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
                //&& Physics.Raycast(transform.position, Vector3.down, GetComponent<Collider>().bounds.extents.y + 0.1f))
            {
                if (col.contacts[0].point.y > transform.position.y)
                {
                    Invoke("Drop", TimeBeforeFall);
                }
            }
        }

        void Drop()
        {
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
        }
    }
}