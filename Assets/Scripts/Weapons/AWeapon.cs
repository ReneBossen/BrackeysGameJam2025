using Brackeys.SO;
using UnityEngine;

namespace Brackeys.Weapons
{
    public abstract class AWeapon<T> : IWeapon
        where T : AWeaponInfo
    {
        protected AWeapon(T info)
        {
            Info = info;
            _currentAmmoCount = BaseInfo.RequiresExternalAmmosCount;
        }

        public T Info { set; get; }
        private int _currentAmmoCount;

        public AWeaponInfo BaseInfo => Info;

        protected bool CanShoot => _currentAmmoCount >= BaseInfo.RequiresExternalAmmosCount;

        public virtual void Fire(Vector3 spawnPos, Vector3 forward, Vector3 gunModel, Quaternion rot)
        {
            if (BaseInfo.EjectAmmoGameObject != null)
            {
                for (int i = 0; i < BaseInfo.RequiresExternalAmmosCount; i++)
                {
                    var go = GameObject.Instantiate(BaseInfo.EjectAmmoGameObject, gunModel, Quaternion.identity);

                    var t = forward;
                    t.y = 0f;
                    go.GetComponent<Rigidbody>().linearVelocity = (Quaternion.Euler(0f, -90f, 0f) * t).normalized * Random.Range(2f, 5f);
                }
                _currentAmmoCount = 0;
            }
        }

        public bool NeedAmmo()
        {
            return _currentAmmoCount < BaseInfo.RequiresExternalAmmosCount;
        }

        public bool AddAmmo()
        {
            if (NeedAmmo())
            {
                _currentAmmoCount++;
                return !NeedAmmo();
            }
            return true;
        }
    }
}