using UnityEngine;

namespace Brackeys.Weapon
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public GameObject BulletSpawnPoint;

        public abstract void Fire();
        public abstract void Reload();

        public void Throw()
        {
            Debug.Log("Throwing weapon");
        }
    }
}
