namespace Assets.Scripts
{
    using UnityEngine;

    public class ScroolBackground : MonoBehaviour
    {
        public float Speed = 0.1f;

        private Renderer myRenderer;

        // Use this for initialization
        void Start()
        {
            myRenderer = GetComponent<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
            var offset = new Vector2(Time.time * Speed, 0);
            myRenderer.material.mainTextureOffset = offset;
        }
    }
}