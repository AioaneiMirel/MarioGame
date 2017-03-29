namespace Assets.Scripts
{
    using UnityEngine;

    public class MovingPlatforms : MonoBehaviour
    {
        public Transform MovingTransform;

        public Transform Position1;

        public Transform Position2;

        public Vector3 NewPosition;

        public string CurrentState;

        public float Smooth;

        public float ResetTime;

        // Use this for initialization
        void Start()
        {
            ChangeTarget();
        }

        // Update is called once per frame
        void FixedUpdate() //for consistent interval independent of pc speed
        {
            MovingTransform.position = Vector3.Lerp(MovingTransform.position, NewPosition, Smooth * Time.deltaTime);
        }

        void ChangeTarget()
        {
            if (CurrentState == "Moving to position 1")
            {
                CurrentState = "Moving to position 2";
                NewPosition = Position2.position;
            }
            else
            {
                if (CurrentState == "Moving to position 2")
                {
                    CurrentState = "Moving to position 1";
                    NewPosition = Position1.position;
                }
                else
                {
                    if (CurrentState == "") //at start game
                    {
                        CurrentState = "Moving to position 2";
                        NewPosition = Position2.position;
                    }
                }
            }
            Invoke("ChangeTarget", ResetTime);
        }

    }
}