using UnityEngine;

namespace Brackeys.Weapons
{
    public class Bullet : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}