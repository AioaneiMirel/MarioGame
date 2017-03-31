namespace Assets.Scripts
{
    using UnityEngine;

    public class Coin : MonoBehaviour
    {
        public int SpinSpeed = 1;

        // Use this for initialization
        private AudioSource audioSource;

        // Use this for initialization
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(0, 5 * SpinSpeed, 0, Space.World);
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == "Player")
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                audioSource.Play();
                Invoke("Destroy", audioSource.clip.length);
            }
        }

        void Destroy()
        {
            Destroy(gameObject);
        }
    }
}