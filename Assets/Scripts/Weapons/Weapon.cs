using UnityEngine;

namespace Brackeys.Weapons
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public GameObject BulletSpawnPoint;
        public abstract void Fire();
        public abstract void Reload();
    }
}
