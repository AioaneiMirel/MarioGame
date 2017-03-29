namespace Assets.Scripts
{
    using UnityEngine;

    public class LevelEnd : MonoBehaviour
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

                Invoke("Lose", audioSource.clip.length); //wait clip to finish play then call method        
            }
        }

        void Lose()
        {
            LevelManager.LoadLevel("Lose");
        }
    }
}