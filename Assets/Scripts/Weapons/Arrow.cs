using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Weapons
{
    public class Arrow : Bullet
    {
        protected override void OnHit(Collider collision, Vector3 _)
        {
            Debug.Log($"[ARR] Touched {collision.name}");
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;

            if (collision.gameObject.TryGetComponent<IShootable>(out var shootable))
            {
                shootable.OnShot();
            }
            transform.parent = collision.transform;
        }
    }
}