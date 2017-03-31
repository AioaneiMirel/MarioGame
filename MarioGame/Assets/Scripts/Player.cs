namespace Assets.Scripts
{
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        public float Speed = 3.0f;

        public float JumpForce = 2.0f;

        public AudioClip[] Clips;

        Rigidbody rigidBody;

        bool onJumpPlatform = false;

        void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Move();
            Jump();
            //Debug.DrawRay(transform.position, new Vector3(0, -2, 0), Color.green);//Debug porpuses 
        }

        void Jump()
        {
            var jump = new Vector3(0.0f, 2.0f, 0.0f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (IsOnGround())
                {
                    rigidBody.AddForce(jump * JumpForce, ForceMode.Impulse);
                    PlayClip("Jump_Low");
                }
                if (onJumpPlatform)
                {
                    rigidBody.AddForce(jump * JumpForce * 0.5f, ForceMode.Impulse);
                    PlayClip("Jump_High");
                    onJumpPlatform = false;
                }
            }
        }

        bool IsPlatformHit()
        {
            return Physics.Raycast(transform.position, Vector3.down, GetComponent<Collider>().bounds.extents.y + 0.1f);
        }

        bool HeadHit()
        {
            return Physics.Raycast(transform.position, Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
        }

        void Move()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            transform.position += move * Speed * Time.deltaTime;
        }

        bool IsOnGround()
        {
            return Physics.Raycast(transform.position, Vector3.down, GetComponent<Collider>().bounds.extents.y + 0.1f);
        }

        void OnCollisionEnter(Collision col)
        {
            if (HeadHit())
            {
                if (col.gameObject.tag == "WallBrickStandard")
                {
                    PlayClip("Brick_Hit");
                }
                if (col.gameObject.tag == "WallBrickDestroyed")
                {
                    col.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    PlayClip("Brick_Hit"); //TO DO Find another sound to play when a brick is destroyed
                }
            }

            if (IsPlatformHit() && col.gameObject.tag == "JumpPlatform")
            {
                onJumpPlatform = true;
            }
        }

        void OnCollisionExit(Collision col)
        {
            onJumpPlatform = false;
        }

        void PlayClip(string clipName)
        {
            switch (clipName)
            {
                case "Jump_Low":
                    Play(0);
                    break;
                case "Die":
                    Play(1);
                    break;
                case "Brick_Hit":
                    Play(2);
                    break;
                case "Jump_High":
                    Play(3);
                    break;
            }
        }

        private void Play(int index)
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.clip = Clips[index];
            audioSource.Play();
        }
    }
}