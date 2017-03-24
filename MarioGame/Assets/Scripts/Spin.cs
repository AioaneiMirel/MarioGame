namespace Assets.Scripts
{
    using UnityEngine;

    public class Spin : MonoBehaviour
    {
        public int Speed = 1;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(0, 5 * Speed, 0, Space.World);
        }
    }
}