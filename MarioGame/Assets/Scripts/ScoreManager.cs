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
        private int lifes;

        private Text scoreText;
        private Text coinText;
        private Text lifesText;

        public void Collect(int passedValue, GameObject passedObject)
        {
            score = score + passedValue;
            scoreText.text = "Score :" + score;

            if (passedObject.tag=="Coin")
            {
                coins += 1;
                coinText.text = "Coins: " + coins;
            }
            if (coins%10==0 || passedObject.tag=="ExtraLife")
            {
                lifes += 1;
                lifesText.text = "Life: " + lifes;
            }
        }

        void Awake()
        {
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


        public void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}