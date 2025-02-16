using System;
using UnityEngine;

namespace Brackeys.Weapon
{
    public class Pistol : Weapon
    {
        [SerializeField] private GameObject _bulletPrefab;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Throw();
            }

        }

        public override void Fire()
        {
            GameObject bullet = Instantiate(_bulletPrefab, BulletSpawnPoint.transform.position, BulletSpawnPoint.transform.rotation);
        }

        public override void Reload()
        {
            Debug.Log("Reloading");
        }
    }
}
