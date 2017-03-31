namespace Assets.Scripts
{
    using UnityEngine;

    public class Collectable : MonoBehaviour
    {
        public int Value = 100;

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
            if (col.gameObject.tag == "Player")
            {
                ScoreManager.Instance.Collect(Value, gameObject);
            }
        }
    }
}