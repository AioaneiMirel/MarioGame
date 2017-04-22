namespace Assets.Scripts
{
    using UnityEngine;
    using UnityEngine.UI;

    public class EnemyHealth : MonoBehaviour
    {
        public int Health;

        private int maxHealth;

        private Image healthBar;

        public void Hit(int damage)
        {
            Health -= damage;
            healthBar.fillAmount = (float)Health / (float)maxHealth;
            if (Health == 0)
            {
                DestroyObject(gameObject);
            }
        }

        // Use this for initialization
        void Start()
        {
            maxHealth = Health;
            healthBar = transform.FindChild("EnemyCanvas")
                .FindChild("HealthBG")
                .FindChild("Health")
                .GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Bullet")
            {
                Hit(10);
            }
        }
    }
}