namespace Assets.Scripts
{
    using UnityEngine;

    public class Collectable : MonoBehaviour
    {
        public int Value = 100;

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                if (gameObject.tag == "ExtraLife")
                {
                    ScoreManager.Instance.Collect(1000, gameObject);
                }
                else
                {
                    ScoreManager.Instance.Collect(Value, gameObject);
                }
            }
        }
    }
}