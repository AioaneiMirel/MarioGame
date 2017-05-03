namespace Assets.Scripts
{
    using UnityEngine;

    public class PlayerShoot : MonoBehaviour
    {
        public GameObject BulletEmitter;

        public GameObject Bullet;

        public float BulletForwardForce;

        public bool ReverseDirection;

        public int BulletSpeed;

        public int FireRate;

        private string faceDirection;

        private bool canShootAgain;

        void Start()
        {
            faceDirection = "Right";
            canShootAgain = true;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                faceDirection = "Right";
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                faceDirection = "Left";
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (canShootAgain)
                {
                    //moveing in a direction
                    GameObject temporaryBulletHandler;
                    if (faceDirection == "Right")
                    {
                        temporaryBulletHandler = Instantiate(
                                                     Bullet,
                                                     BulletEmitter.transform.position,
                                                     BulletEmitter.transform.rotation) as GameObject;

                        RevereDirectionToFire(temporaryBulletHandler, true);
                    }
                    else if (faceDirection == "Left")
                    {
                        temporaryBulletHandler = Instantiate(
                                                     Bullet,
                                                     BulletEmitter.transform.position - new Vector3(3, 0, 0),
                                                     BulletEmitter.transform.rotation) as GameObject;

                        RevereDirectionToFire(temporaryBulletHandler, false);
                    }

                    canShootAgain = false;
                    Invoke("CanShootAgain", 0.2f * FireRate);
                }
            }
        }

        void RevereDirectionToFire(GameObject temporaryBulletHandler, bool reverse)
        {
            var temporaryRigidBody = temporaryBulletHandler.GetComponent<Rigidbody>();

            if (reverse)
            {
                temporaryRigidBody.AddForce(new Vector3(BulletSpeed, 0, 0) * BulletForwardForce);
            }
            else
            {
                temporaryRigidBody.AddForce(new Vector3(-BulletSpeed, 0, 0) * BulletForwardForce);
            }
        }

        void CanShootAgain()
        {
            canShootAgain = true;
        }
    }
}