using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFollow : MonoBehaviour
    {

        // Use this for initialization
        public float xMax;
        public float YMax;
        
        public float xMin;
        public float yMin;

        public GameObject Player;
        public Vector3 Offset;

        private Transform target;

        void Start()
        {
            //Offset = transform.position - Player.transform.position;
            target = GameObject.Find("Player").transform; 
        }

        // Update is called once per frame
        void LateUpdate()
        {
            //transform.position = Player.transform.position + Offset;
            transform.position=new Vector3(Mathf.Clamp(target.position.x,xMin,xMax),Mathf.Clamp(target.position.y,yMin,YMax),transform.position.z);
        }
    }
}
