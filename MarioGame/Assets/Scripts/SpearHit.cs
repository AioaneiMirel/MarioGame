namespace Assets.Scripts
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SpearHit : MonoBehaviour
    {
        public LevelManager LevelManager;
        // Use this for initialization
        void Start()
        {
            LevelManager = (LevelManager)FindObjectOfType(typeof(LevelManager));
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                LevelManager.LoadLevel(SceneManager.GetActiveScene().name);
            }
        }
    }
}