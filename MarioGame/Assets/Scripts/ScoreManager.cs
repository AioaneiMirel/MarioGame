namespace Assets.Scripts
{
    using System;
    using System.Linq;

    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance = null;

        public GameObject ScoreText;

        public GameObject CoinsText;

        public GameObject LifeText;

        public GameObject LevelText;

        public GameObject KeysText;

        public int lifes;

        public int score;

        public int coins;

        public int level;

        public int keys;

        private Text scoreText;

        private Text coinText;

        private Text lifesText;

        private Text levelText;

        private Text keysText;

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

            if (passedObject.tag == "Portal")
            {
                var currentScene = SceneManager.GetActiveScene();
                level = Convert.ToInt32(currentScene.name.Split('_').Last());
                level++;
                levelText.text = "Level: " + level;
            }

            if (passedObject.tag == "Key")
            {
                
                keys--;
                keysText.text = "Keys Left: " + keys;
            }
        }

        public void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        void Awake()
        {
            lifes = 3;
            level = 1;
            keys = 3;
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
            levelText = LevelText.GetComponent<Text>();
            keysText = KeysText.GetComponent<Text>();

            scoreText.text = "Score: " + score;
            coinText.text = "Coins: " + coins;
            lifesText.text = "Life: " + lifes;
            levelText.text = "Level: " + level;
        }
    }
}