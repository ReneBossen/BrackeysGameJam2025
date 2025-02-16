using Brackeys.Interfaces;
using Brackeys.Manager;
using Brackeys.SO;
using UnityEngine;

namespace Brackeys.Weapons
{
    public class Bullet : MonoBehaviour
    {
        private ProjectileWeaponInfo _info;
        public ProjectileWeaponInfo Info
        {
            set
            {
                _info = value;
                _bounceLeft = _info.MaxBounceCount.GetValue();
            }
            private get => _info;
        }
        int _bounceLeft = 1;

        private void OnCollisionEnter(Collision collision)
        {
            _bounceLeft--;
            if (_bounceLeft <= 0)
            {
                if (Info.SpawnOnImpact != null)
                {
                    Destroy(Instantiate(Info.SpawnOnImpact, collision.contacts[0].point, Quaternion.identity), Info.DurationBeforeDelete);
                }

                if (Info.DoesExplode)
                {
                    DebugManager.Instance.AddSphere(Info.ExplosionRadius, Color.red, 1f, collision.contacts[0].point);
                    foreach (var s in Physics.OverlapSphere(collision.contacts[0].point, Info.ExplosionRadius, LayerMask.GetMask("Prop")))
                    {
                        if (s.TryGetComponent<IShootable>(out var shootable))
                        {
                            shootable.OnShot();
                        }
                    }
                }
                else if (collision.gameObject.TryGetComponent<IShootable>(out var shootable))
                {
                    shootable.OnShot();
                }

                Destroy(gameObject);
            }
        }
    }
}