using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Weapons
{
    public class Bullet : MonoBehaviour
    {
        public int BounceLeft { set; get; } = 1;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IShootable>(out var shootable))
            {
                shootable.OnShot();
            }
            BounceLeft--;
            if (BounceLeft <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}