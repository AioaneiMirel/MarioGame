namespace Assets.Scripts
{
    using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        // Use this for initialization
        public float XMax;

        public float YMax;

        public float XMin;

        public float YMin;

        private Transform target;

        void Start()
        {
            target = GameObject.Find("Player").transform;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = new Vector3(
                                     Mathf.Clamp(target.position.x, XMin, XMax),
                                     Mathf.Clamp(target.position.y, YMin, YMax),
                                     transform.position.z);
        }
    }
}