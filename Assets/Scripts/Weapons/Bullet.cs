using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Weapons
{
    public class Bullet : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IShootable>(out var shootable))
            {
                shootable.OnShot();
            }
            Destroy(gameObject);
        }
    }
}