using System;
using UnityEngine;

namespace Brackeys.Weapons
{
    public class Pistol : Weapon
    {
        [SerializeField] private GameObject _bulletPrefab;

        public override void Fire()
        {
            Debug.Log("Firing");
            //GameObject bullet = Instantiate(_bulletPrefab, BulletSpawnPoint.transform.position, BulletSpawnPoint.transform.rotation);
        }

        public override void Reload()
        {
            Debug.Log("Reloading");
        }
    }
}