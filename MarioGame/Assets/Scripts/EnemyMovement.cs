namespace Assets.Scripts
{
    using UnityEngine;

    public class EnemyMovement : MonoBehaviour
    {
        public float Speed = 1.0f;

        public float XMax;

        private Vector3 initialPos;

        private Vector3 endPos;

        void Start()
        {
            initialPos = transform.position;
            endPos.x = XMax;
            endPos.y = transform.position.y;
        }

        void Update()
        {
            transform.position = Vector3.Lerp(initialPos, endPos, Mathf.PingPong(Time.time * Speed, 1.0f));
        }
    }
}