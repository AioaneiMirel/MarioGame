namespace Assets.Scripts
{
    using UnityEngine;

    public class EnableStairs : MonoBehaviour
    {
        public Transform MoveThisObject;

        public Transform FinalPosition;

        public bool StartMoveing;

        // Use this for initialization
        void Start()
        {
            StartMoveing = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (StartMoveing)
            {
                gameObject.transform.position = Vector3.MoveTowards(
                    transform.position,
                    FinalPosition.position,
                    Time.deltaTime / 3);
            }
        }
    }
}