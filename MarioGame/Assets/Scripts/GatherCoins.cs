namespace Assets.Scripts
{
    using UnityEngine;

    public class GatherCoins : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}