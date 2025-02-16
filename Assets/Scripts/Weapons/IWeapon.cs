using UnityEngine;

namespace Brackeys.Weapons
{
    public interface IWeapon
    {
        public void Fire(Vector3 spawnPos, Vector3 forward);
    }
}