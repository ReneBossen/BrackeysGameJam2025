using Brackeys.SO;
using UnityEngine;

namespace Brackeys.Weapons
{
    public abstract class AWeapon<T> : IWeapon
        where T : AWeaponInfo
    {
        public T Info { set; get; }

        public abstract void Fire(Vector3 spawnPos, Vector3 forward);
    }
}