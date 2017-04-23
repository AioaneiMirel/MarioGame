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
            //int lifes = //Convert.ToInt32(scoreManager.LifeText.GetComponent<Text>().text.Split(':').Last());
            if (scoreManager.lifes<0 && NextLevelName=="Level_01")
            {
                scoreManager.lifes = 3;
                scoreManager.LifeText.GetComponent<Text>().text = "Life: " + 3;
            }
            SceneManager.LoadScene(NextLevelName);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}