namespace Assets.Scripts
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class LevelEndReset : MonoBehaviour
    {
        public LevelManager LevelManager;

        private AudioSource audioSource;

        // Use this for initialization
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                audioSource.Play();

                Invoke("ResetLevel", audioSource.clip.length); //wait clip to finish play then call method        
            }
        }

        void ResetLevel()
        {
            LevelManager.LoadLevel(SceneManager.GetActiveScene().name);
        }
    }
}