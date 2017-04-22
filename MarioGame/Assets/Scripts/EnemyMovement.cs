namespace Assets.Scripts
{
    using System;

    using UnityEngine;

    using Random = System.Random;

    public class EnemyMovement : MonoBehaviour
    {
        //public float moveForce = 2f;

        //public float HitDistance;

        //public float maxX, minX;

        //private Rigidbody rBody;

        //private bool reverse;

        //private int countHits;

        //// Use this for initialization
        //void Start()
        //{
        //    rBody = GetComponent<Rigidbody>();
        //    reverse = false;
        //    countHits = 0;
        //}

        //// Update is called once per frame
        //void Update()
        //{
        //    Move();

        //    //ChangeMovementDirectionIfWallIsHit();

        //    //Physics.Raycast(transform.position, transform.forward, 2);
        //    Debug.DrawRay(transform.position, transform.right + new Vector3(HitDistance, 0, 0), Color.red);
        //}

        //void ChangeMovementDirectionIfWallIsHit()
        //{
        //    if (Physics.Raycast(transform.position, transform.right + new Vector3(HitDistance, 0, 0), HitDistance))
        //    {
        //        transform.position += new Vector3(-1, 0, 0) * 2 * Time.deltaTime;
        //    }

        //    if (Physics.Raycast(transform.position, -transform.right + new Vector3(HitDistance, 0, 0), HitDistance))
        //    {
        //        transform.position += new Vector3(1, 0, 0) * 2 * Time.deltaTime;
        //    }
        //}

        //void Move()
        //{
        //    //PlayerHit => reverse
        //    //if (reverse)
        //    //{
        //    //    transform.position += new Vector3(-1, 0, 0) * 2 * Time.deltaTime;
        //    //}
        //    //if (!reverse)
        //    //{
        //    //    transform.position += new Vector3(1, 0, 0) * 2 * Time.deltaTime;
        //    //}
        //    //transform.position += new Vector3(1, 0, 0) * 2 * Time.deltaTime;
        //    //WallHit =>reverse

        //    if (transform.position.x <= maxX)
        //    {
        //        transform.position += new Vector3(1, 0, 0) * 2 * Time.deltaTime;
        //    }

        //    else
        //    {

        //    //(transform.position.x >= minX)

        //        transform.position += new Vector3(1, 0, 0) * 2 * Time.deltaTime;
        //    }
        //}

        //void OnCollisionEnter(Collision col)
        //{
        //    if (col.gameObject.tag == "Player")
        //    {
        //        countHits++;
        //        reverse = countHits % 2 == 0;
        //    }
        //}

        //public float moveForce = 0f;

        //private Rigidbody rBody;

        //public Vector3 moveDirection;

        //public LayerMask whatIsWall;

        //public float maxDistanceFromWall = 0f;

        //int countHits;

        //public void Start()
        //{
        //    rBody = GetComponent<Rigidbody>();
        //    moveDirection = ChooseDirection();
        //    transform.rotation = Quaternion.LookRotation(moveDirection);
        //    countHits = 0;
        //}

        //void Update()
        //{
        //    rBody.velocity = moveDirection * moveForce;

        //    if (Physics.Raycast(transform.position,transform.forward, maxDistanceFromWall/*,whatIsWall*/))
        //    {
        //        moveDirection = ChooseDirection();
        //        transform.rotation = Quaternion.LookRotation(moveDirection);
        //    }
        //}



        //Vector3 ChooseDirection()
        //{
        //    //Random ran=new Random();
        //    //int i = ran.Next(0, 1);


        //    countHits++;
        //    //        reverse = ;
        //    Vector3 temp =new Vector3();

        //    if (countHits % 2 == 0)
        //    {
        //        temp = transform.forward;
        //    }

        //    else /*if (i==1)*/
        //    {
        //        temp = -transform.forward;
        //    }

        //    //else if (i == 2)
        //    //{
        //    //    temp = transform.right;
        //    //}
        //    //else if (i == 3)
        //    //{
        //    //    temp = -transform.right;
        //    //}

        //    return temp;


        //}


        private Vector3 initialPos;
        private Vector3 endPos ;
        public float Speed = 1.0f;

        public float XMax;

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