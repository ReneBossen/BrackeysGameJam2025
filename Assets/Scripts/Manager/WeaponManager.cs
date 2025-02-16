using Brackeys.SO;
using Brackeys.Weapons;
using System;
using UnityEngine;

namespace Brackeys
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField]
        private AWeaponInfo[] _weapons;

        public IWeapon CreateWeapon(int i)
        {
            var weapon = _weapons[i];

            if (weapon is ProjectileWeaponInfo wInfo)
            {
                return new ProjectileWeapon(wInfo);
            }

            throw new NotImplementedException();
        }
    }
}