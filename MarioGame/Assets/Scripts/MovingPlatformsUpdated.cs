namespace Assets.Scripts
{
    using UnityEngine;

    public class MovingPlatformsUpdated : MonoBehaviour
    {
        public Transform MoveThisObject;

        public Transform[] Positions;

        private Vector3 NextPosition;

        private int CurrentPosition;

        public float Smooth;

        public float ResetTime;

        bool reverse;

        // Use this for initialization
        void Start()
        {
            ChangeTarget();
        }

        // Update is called once per frame
        void FixedUpdate() //for consistent interval independent of pc speed
        {
            MoveThisObject.position = Vector3.LerpUnclamped(MoveThisObject.position, NextPosition, Smooth * Time.deltaTime);
        }
        
        void ChangeTarget()
        {
            //Debug.Log(CurrentPosition);
            if (CurrentPosition == 0) //at start game
            {
                reverse = false;
                CurrentPosition += 1;
                NextPosition = Positions[CurrentPosition].position;
            }
            else
            {
                if (CurrentPosition < Positions.Length-1)
                {
                    if (!reverse)
                    {
                        CurrentPosition += 1;
                        NextPosition = Positions[CurrentPosition].position;
                    }
                    else
                    {
                        CurrentPosition -= 1;
                        NextPosition = Positions[CurrentPosition].position;
                    }
                }
                else
                {
                    CurrentPosition -= 1;
                    NextPosition = Positions[CurrentPosition].position;
                    reverse = true;
                }
            }
            Invoke("ChangeTarget", ResetTime);
        }
    }
}