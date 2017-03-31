namespace Assets.Scripts
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance = null;

        public GameObject ScoreText;

        private int score;

        private Text scoreText;

        public void Collect(int passedValue, GameObject passedObject)
        {
            score = score + passedValue;
            scoreText.text = "Score " + score;
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
            scoreText.text = "Score: " + score;
        }
    }
}