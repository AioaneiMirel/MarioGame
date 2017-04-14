namespace Assets.Scripts
{
    using UnityEngine;

    public class ExtraLife : MonoBehaviour
    {
        public float XSpeed;

        public float YSpeed;

        public float ZSpeed;

        // Use this for initialization

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(
                5 * XSpeed * Time.deltaTime,
                5 * YSpeed * Time.deltaTime,
                5 * YSpeed * Time.deltaTime,
                Space.World);
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag=="Player")
            {
                Destroy(gameObject);
            }
        }
    }
}