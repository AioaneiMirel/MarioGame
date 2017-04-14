namespace Assets.Scripts
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class LevelManager : MonoBehaviour
    {
        public string NextLevelName;
        public void LoadLevel(string NextLevelName)
        {
            SceneManager.LoadScene(NextLevelName);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}