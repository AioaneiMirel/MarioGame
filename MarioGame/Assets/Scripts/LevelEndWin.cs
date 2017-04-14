namespace Assets.Scripts
{
    using UnityEngine;

    public class LevelEndWin : MonoBehaviour
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

                Invoke("EndLevelWin", audioSource.clip.length); //wait clip to finish play then call method        
            }
        }

        void EndLevelWin()
        {
            LevelManager.LoadLevel(LevelManager.NextLevelName);
        }
    }
}