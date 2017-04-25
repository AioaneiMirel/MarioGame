namespace Assets.Scripts
{
    using System;
    using System.Linq;

    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class LevelManager : MonoBehaviour
    {
        public string NextLevelName;
        public void LoadLevel(string NextLevelName)
        {
            var scoreManager= (ScoreManager)FindObjectOfType(typeof(ScoreManager));
            
            if (scoreManager.lifes<0 && NextLevelName=="Level_01")
            {
                scoreManager.lifes = 3;
                scoreManager.score = 0;
                scoreManager.coins = 0;
                
                scoreManager.LifeText.GetComponent<Text>().text = "Life: " + 3;
                scoreManager.LevelText.GetComponent<Text>().text = "Level: " + 1;
                scoreManager.ScoreText.GetComponent<Text>().text = "Score: " + 0;
                scoreManager.CoinsText.GetComponent<Text>().text = "Coins: " + 0;
                
            }

            if (NextLevelName == "Level_01")
            {
                scoreManager.keys = 3;
                scoreManager.KeysText.GetComponent<Text>().text = String.Empty;
            }

            if (NextLevelName == "Level_06")
            {
                scoreManager.KeysText.GetComponent<Text>().text = "Keys Left: " + scoreManager.keys;
            }
            SceneManager.LoadScene(NextLevelName);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}