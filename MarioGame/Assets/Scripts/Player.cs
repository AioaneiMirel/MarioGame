namespace Assets.Scripts
{
    using System;

    using UnityEngine;
    using UnityEngine.UI;

    public class Player : MonoBehaviour
    {
        public float Speed = 3.0f;

        public float JumpForce = 2.0f;

        public AudioClip[] Clips;

        Rigidbody rigidBody;

        bool onJumpPlatform;

        private PlayerShoot ps;

        void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            PauseMenu.HideInGameMenu();
        }

        void Update()
        {
            GameMenu();
            Move();
            Jump();
            //Debug.DrawRay(transform.position, new Vector3(0, -2, 0), Color.green);//Debug porpuses 
        }

        private void GameMenu()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu.ShowInGameMenu();
                Time.timeScale = 0.0f;
            }
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
            Debug.DrawRay(transform.position, new Vector3(0, 2, 0), Color.green);
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
            if (HeadHit() && !IsOnGround())
            {
                if (col.gameObject.tag == "WallBrickStandard")
                {
                    PlayClip("Brick_Hit");
                }
                if (col.gameObject.tag == "WallBrickDestroyed")
                {
                    PlayClip("Brick_Hit"); //TO DO Find another sound to play when a brick is destroyed
                }
            }

            if (IsPlatformHit() && col.gameObject.tag == "JumpPlatform")
            {
                onJumpPlatform = true;
            }

            if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "Fire_Ball"
                || col.gameObject.tag == "Spear_Head")
            {
                var scoreManager = (ScoreManager)FindObjectOfType(typeof(ScoreManager));
                var uiText = scoreManager.LifeText.GetComponent<Text>();
                var life = uiText.text;
                var lifesLeft = life.Split(':')[1];
                if (Convert.ToInt32(lifesLeft) < 0)
                {
                    var levelManager = (LevelManager)FindObjectOfType(typeof(LevelManager));
                    levelManager.LoadLevel("Lose");
                }
                Debug.Log(lifesLeft);
            }

            if (col.gameObject.tag == "Weapon")
            {
                ps = gameObject.GetComponent<PlayerShoot>();
                ps.enabled = true;
            }
        }

        void OnCollisionExit(Collision col)
        {
            onJumpPlatform = false;
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Die")
            {
                var scoreManager = (ScoreManager)FindObjectOfType(typeof(ScoreManager));
                var uiText = scoreManager.LifeText.GetComponent<Text>();
                var life = uiText.text;
                var lifesLeft = life.Split(':')[1];
                if (Convert.ToInt32(lifesLeft) < 0)
                {
                    var levelManager = (LevelManager)FindObjectOfType(typeof(LevelManager));
                    levelManager.LoadLevel("Lose");
                }
                Debug.Log(lifesLeft);
            }
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