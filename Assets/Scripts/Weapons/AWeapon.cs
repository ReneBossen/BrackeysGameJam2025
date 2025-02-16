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
        }

        public T Info { set; get; }

        public AWeaponInfo BaseInfo => Info;

        public abstract void Fire(Vector3 spawnPos, Vector3 forward);
    }
}