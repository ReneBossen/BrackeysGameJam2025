using Brackeys.Interfaces;
using Brackeys.Manager;
using UnityEngine;

namespace Brackeys.Weapons
{
    public class Arrow : Bullet
    {
        protected override void OnCollisionEnter(Collision collision)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = false;
            if (collision.gameObject.TryGetComponent<IShootable>(out var shootable))
            {
                shootable.OnShot();
            }
        }
    }
}