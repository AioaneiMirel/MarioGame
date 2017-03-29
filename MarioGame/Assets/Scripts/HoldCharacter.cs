namespace Assets.Scripts
{
    using UnityEngine;

    public class HoldCharacter : MonoBehaviour
    {
        // Use this for initialization
        void OnTriggerEnter(Collider col)
        {
            col.transform.parent = gameObject.transform; //when in collidion with object make thar object it's parent(player does not fall from platform)
        }

        void OnTriggerExit(Collider col)
        {
            col.transform.parent = null;
        }
    }
}