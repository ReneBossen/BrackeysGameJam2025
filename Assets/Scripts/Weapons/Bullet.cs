using Brackeys.Interfaces;
using Brackeys.Manager;
using Brackeys.SO;
using UnityEngine;
using UnityEngine.Splines;

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

        [SerializeField] private Transform _impactPoint;

        private int _bounceLeft = 1;
        private Vector3 _last;
        private bool _isHit;

        private void Awake()
        {
            _last = _impactPoint.position;
            _isHit = false;
        }

        private void Update()
        {
            if (_isHit)
                return;

            Vector3 curr = _impactPoint.position;

            if (Physics.Linecast(curr, _last, out RaycastHit hit, LayerMask.GetMask("Prop", "SpeProp", "Map", "OutsideWall")))
            {
                _isHit = true;
                transform.position = hit.point;
                OnHit(hit.collider, hit.transform.position);
            }

            _last = curr;
        }

        private void OnCollisionEnter(Collision collision)
        {
            OnHit(collision.collider, collision.GetContact(0).point);
        }

        protected virtual void OnHit(Collider collision, Vector3 hitPosition)
        {
            Debug.Log($"[BUL] Touched {collision.name}");
            HandleBounce();
            SpawnImpactEffect(hitPosition);
            HandleExplosion(hitPosition);
            TriggerOnShot(collision);

            Destroy(gameObject);
        }

        private bool HandleBounce()
        {
            _bounceLeft--;

            return _bounceLeft > 0;
        }

        private void SpawnImpactEffect(Vector3 hitPosition)
        {
            if (Info.SpawnOnImpact == null)
                return;

            GameObject effect = Instantiate(Info.SpawnOnImpact, hitPosition, Quaternion.identity);
            Destroy(effect, Info.DurationBeforeDelete);
        }

        private void HandleExplosion(Vector3 hitPosition)
        {
            if (!Info.DoesExplode)
                return;

            DebugManager.Instance.AddSphere(Info.ExplosionRadius, Color.red, 1f, hitPosition);

            foreach (Collider s in Physics.OverlapSphere(hitPosition, Info.ExplosionRadius, LayerMask.GetMask("Prop", "SpeProp")))
            {
                if (s.TryGetComponent(out IShootable shootable))
                {
                    shootable.OnShot();
                }
            }
        }

        private void TriggerOnShot(Collider collision)
        {
            if (Info.DoesExplode)
                return;

            if (collision.TryGetComponent(out IShootable shootable))
            {
                shootable.OnShot();
            }
        }
    }
}