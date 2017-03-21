namespace Assets.Scripts
{
    using UnityEngine;

    public class PlayerMove : MonoBehaviour
    {
        public float Speed = 1.0f;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame

        void Update()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            this.transform.position += move * Speed * Time.deltaTime;
        }
    }
}