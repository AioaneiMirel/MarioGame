namespace Assets.Scripts
{
    using UnityEngine;
    using UnityEngine.UI;

    public class PauseMenu : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void Resume()
        {
            HideInGameMenu();
            Time.timeScale = 1.0f;
        }

        public static void ShowInGameMenu()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameObject.FindGameObjectWithTag("Resume").GetComponentInChildren<Text>().enabled = true;
                GameObject.FindGameObjectWithTag("Resume").GetComponentInChildren<Button>().enabled = true;
                GameObject.FindGameObjectWithTag("Quit").GetComponentInChildren<Text>().enabled = true;
                GameObject.FindGameObjectWithTag("Quit").GetComponentInChildren<Button>().enabled = true;
                GameObject.FindGameObjectWithTag("InGameMenuBackground").GetComponentInChildren<Image>().enabled = true;
            }
        }

        public static void HideInGameMenu()
        {
            GameObject.FindGameObjectWithTag("Resume").GetComponentInChildren<Text>().enabled = false;
            GameObject.FindGameObjectWithTag("Resume").GetComponentInChildren<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("Quit").GetComponentInChildren<Text>().enabled = false;
            GameObject.FindGameObjectWithTag("Quit").GetComponentInChildren<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("InGameMenuBackground").GetComponentInChildren<Image>().enabled = false;
        }
    }
}