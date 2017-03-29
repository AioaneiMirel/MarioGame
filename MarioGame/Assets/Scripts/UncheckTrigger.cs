using UnityEngine;

namespace Assets.Scripts
{
    public class UncheckTrigger : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnTriggerEnter(Collider col)
        {
            if (gameObject.tag == "Player")
            {
                Debug.Log("in trigger");
                GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }
}