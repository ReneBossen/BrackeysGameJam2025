using Brackeys.Player;
using Brackeys.Player.Interaction;
using Brackeys.SO;
using Brackeys.Weapons;
using System;
using UnityEngine;

namespace Brackeys.Props
{
    public class VendingMachine : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private AWeaponInfo[] _weapons;

        public bool CanInteract => true;

        public GameObject GameObject => gameObject;

        public void Interact(PlayerController pc)
        {
            var weapon = _weapons[0];

            if (weapon is ProjectileWeaponInfo wInfo)
            {
                pc.SetWeapon(new ProjectileWeapon(wInfo));
            }
            else throw new NotImplementedException();
        }
    }
}