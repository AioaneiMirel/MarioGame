namespace Assets.Scripts
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance = null;

        public GameObject ScoreText;

        public GameObject CoinsText;

        public GameObject LifeText;

        private int score;

        private int coins;

        public int lifes;

        private Text scoreText;

        private Text coinText;

        private Text lifesText;

        public void CollectOrLoseLife(int passedValue, GameObject passedObject)
        {
            score = score + passedValue;
            scoreText.text = "Score: " + score;

            if (passedObject.tag == "ExtraLife")
            {
                lifes += 1;
                lifesText.text = "Life: " + lifes;
            }

            if (passedObject.tag == "Coin")
            {
                coins += 1;
                coinText.text = "Coins: " + coins;

                if (coins % 10 == 0)
                {
                    lifes += 1;
                    coins = 0;
                    coinText.text = "Coins: " + coins;
                    lifesText.text = "Life: " + lifes;
                }
            }

            if (passedObject.tag == "Die" || passedObject.tag == "Bullet" || passedObject.tag == "Fire_Ball"
                || passedObject.tag == "Spear_Head" || passedObject.tag == "Enemy")
            {
                lifes -= 1;
                lifesText.text = "Life: " + lifes;
            }
        }

        public void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        void Awake()
        {
            lifes = 3;
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                if (Instance != null)
                {
                    Destroy(gameObject);
                }
            }

            scoreText = ScoreText.GetComponent<Text>();
            coinText = CoinsText.GetComponent<Text>();
            lifesText = LifeText.GetComponent<Text>();

            scoreText.text = "Score: " + score;
            coinText.text = "Coins: " + coins;
            lifesText.text = "Life: " + lifes;
        }
    }
}