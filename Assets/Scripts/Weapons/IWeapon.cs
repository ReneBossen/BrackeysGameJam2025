using Brackeys.SO;
using UnityEngine;

namespace Brackeys.Weapons
{
    public interface IWeapon
    {
        public AWeaponInfo BaseInfo { get; }
        public void Fire(Vector3 spawnPos, Transform forwardT, Vector3 gunModel, Quaternion rot);

        /// <returns>Is the weapon full of ammo</returns>
        public bool AddAmmo();
        public bool NeedAmmo();
    }
}