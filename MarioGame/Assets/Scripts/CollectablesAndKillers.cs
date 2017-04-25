namespace Assets.Scripts
{
    using UnityEngine;

    public class CollectablesAndKillers : MonoBehaviour
    {
        public int Value = 100;

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                if (gameObject.tag == "ExtraLife")
                {
                    ScoreManager.Instance.CollectOrLoseLife(1000, gameObject);
                }
                if (gameObject.tag == "Coin")
                {
                    ScoreManager.Instance.CollectOrLoseLife(Value, gameObject);
                }

                if (gameObject.tag == "Weapon")
                {
                    ScoreManager.Instance.CollectOrLoseLife(Value, gameObject);
                }

                if (gameObject.tag=="Key")
                {
                    ScoreManager.Instance.CollectOrLoseLife(Value, gameObject);
                }

                if (gameObject.tag == "Bullet" || gameObject.tag == "Fire_Ball" || gameObject.tag == "Spear_Head"
                    || gameObject.tag == "Enemy")
                {
                    ScoreManager.Instance.CollectOrLoseLife(0, gameObject);
                }
            }
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                if (gameObject.tag == "Die" || gameObject.tag == "Portal")
                {
                    ScoreManager.Instance.CollectOrLoseLife(0, gameObject);
                }
            }
        }
    }
}