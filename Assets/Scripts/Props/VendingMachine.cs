using Brackeys.Animations;
using Brackeys.Player;
using Brackeys.Player.Interaction;
using Brackeys.SO;
using Brackeys.Translation;
using Brackeys.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Brackeys.Props
{
    public class VendingMachine : MonoBehaviour, IInteractable
    {
        public static VendingMachine Instance { private set; get; }

        [SerializeField]
        private List<AWeaponInfo> _weaponsTier0, _weaponsTier1;

        [SerializeField]
        private TMP_Text _weaponNameText, _weaponNameDescription;

        public bool CanInteract { set; get; } = true;

        public GameObject GameObject => gameObject;
        private Animator _animator;

        private void Awake()
        {
            Instance = this;
            _animator = GetComponent<Animator>();

            _weaponNameText.text = Translate.Instance.Tr("pendingCoin");
            _weaponNameDescription.text = string.Empty;
        }

        public void ResetMachine()
        {
            CanInteract = true;
            _weaponNameText.text = Translate.Instance.Tr("pendingCoin");
            _weaponNameDescription.text = string.Empty;
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

            _weaponNameText.text = Translate.Instance.Tr(weapon.NameKey);
            _weaponNameDescription.text = Translate.Instance.Tr(weapon.DescriptionKey);

            _animator.Play(AnimationNames.FlapOpen);

            if (weapon is ProjectileWeaponInfo wInfo)
            {
                pc.SetWeapon(new ProjectileWeapon(wInfo));
            }
            else
                throw new NotImplementedException();
        }
    }
}