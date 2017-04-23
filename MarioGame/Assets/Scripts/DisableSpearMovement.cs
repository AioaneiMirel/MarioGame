namespace Assets.Scripts
{
    using UnityEngine;

    public class DisableSpearMovement : MonoBehaviour
    {
        private int keysColected;

        public GameObject[] DisableSpears;
        // Use this for initialization
        void Start()
        {
            keysColected = 0;
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag=="Key")
            {
                keysColected++;
            }

            if (keysColected==3)
            {
                foreach (var spear in DisableSpears)
                {
                    Destroy(spear);
                }
            }
        }
    }
}