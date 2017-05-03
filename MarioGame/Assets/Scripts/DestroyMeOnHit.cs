namespace Assets.Scripts
{
    using UnityEngine;

    public class DestroyMeOnHit : MonoBehaviour
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
            //destroy entire trap object            
            Destroy(this.gameObject.transform.parent.parent.gameObject);
        }
    }
}