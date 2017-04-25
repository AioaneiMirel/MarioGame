namespace Assets.Scripts
{
    using UnityEngine;

    public class ScroolingChaseingBackgroundWithCamera : MonoBehaviour
    {
        public float ScroolSpeed = 10f;
        
        public float BackgroundDistance = 24;

        public Camera MyCamera;

        private Renderer renderer;

        // Use this for initialization
        void Start()
        {
            renderer = GetComponent<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
            var offset = new Vector2(MyCamera.transform.position.x, MyCamera.transform.position.y);

            renderer.material.mainTextureOffset = offset / ScroolSpeed;

            Vector3 temp = new Vector3(MyCamera.transform.position.x, MyCamera.transform.position.y, BackgroundDistance);
            transform.position = temp;
        }
    }
}