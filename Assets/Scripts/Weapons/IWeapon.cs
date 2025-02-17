using Brackeys.SO;
using UnityEngine;

namespace Brackeys.Weapons
{
    public interface IWeapon
    {
        public AWeaponInfo BaseInfo { get; }
        public void Fire(Vector3 spawnPos, Vector3 forward, Vector3 gunModel);
    }
}