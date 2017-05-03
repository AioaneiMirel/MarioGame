namespace Assets.Scripts
{
    using UnityEngine;

    public class TrapEnable : MonoBehaviour
    {
        public Transform MoveThisObject;

        public Transform FinalPosition;

        public float Speed = 2f;

        public bool IsEnabled;

        // Use this for initialization
        void Start()
        {
            IsEnabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (IsEnabled)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    FinalPosition.position,
                    Time.deltaTime * Speed);
            }
        }
    }
}