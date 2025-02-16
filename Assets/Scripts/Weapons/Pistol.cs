using System;
using UnityEngine;

namespace Brackeys.Weapons
{
    public class Pistol : Weapon
    {
        [SerializeField] private GameObject _bulletPrefab;

        public override void Fire()
        {
            Debug.Log("Pistol Fire Triggered");
        }

        public override void Reload()
        {
            Debug.Log("Pistol Reload Triggered");
        }
    }
}