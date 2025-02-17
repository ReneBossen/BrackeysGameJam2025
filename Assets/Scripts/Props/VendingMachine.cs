using Brackeys.Animations;
using Brackeys.Player;
using Brackeys.Player.Interaction;
using Brackeys.SO;
using Brackeys.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Brackeys.Props
{
    public class VendingMachine : MonoBehaviour, IInteractable
    {
        public static VendingMachine Instance { private set; get; }

        [SerializeField]
        private List<AWeaponInfo> _weaponsTier0, _weaponsTier1;

        public bool CanInteract { set; get; } = true;

        public GameObject GameObject => gameObject;
        private Animator _animator;

        private void Awake()
        {
            Instance = this;
            _animator = GetComponent<Animator>();
        }

        private AWeaponInfo GetRandomWeapon(IList<AWeaponInfo> list)
        {
            var index = UnityEngine.Random.Range(0, list.Count);
            var e = list[index];
            list.RemoveAt(index);
            return e;
        }

        public void Interact(PlayerController pc)
        {
            CanInteract = false;
            var weapon = GetRandomWeapon(_weaponsTier0.Any() ? _weaponsTier0 : _weaponsTier1);

            _animator.Play(AnimationNames.OpenVendingMachine);

            if (weapon is ProjectileWeaponInfo wInfo)
            {
                pc.SetWeapon(new ProjectileWeapon(wInfo));
            }
            else
                throw new NotImplementedException();
        }
    }
}