using Brackeys.Animations;
using Brackeys.Manager;
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

        private string _nameKey, _descKey;

        private void Awake()
        {
            Instance = this;
            _animator = GetComponent<Animator>();

            _nameKey = "pendingCoin";
            _descKey = null;
            ResetTranslation();
        }

        private void Start()
        {
            Translate.Instance.OnTranslationChange += (_a, _b) => { ResetTranslation(); };
        }

        public void ResetMachine()
        {
            CanInteract = true;
            _nameKey = "pendingCoin";
            _descKey = null;
            ResetTranslation();
        }

        private void ResetTranslation()
        {
            _weaponNameText.text = Translate.Instance.Tr(_nameKey);
            _weaponNameDescription.text = _descKey == null ? string.Empty : Translate.Instance.Tr(_descKey);
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
            if (ResourceManager.Instance.PlayerInput.CurrentWeapon != null)
            {
                while (ResourceManager.Instance.PlayerInput.CurrentWeapon.NeedAmmo()) ResourceManager.Instance.PlayerInput.CurrentWeapon.AddAmmo();
                return;
            }
            var weapon = GetRandomWeapon(_weaponsTier0.Any() ? _weaponsTier0 : _weaponsTier1);

            _nameKey = weapon.NameKey;
            _descKey = weapon.DescriptionKey;
            ResetTranslation();

            LevelStateManager.Instance.OpenDoor();
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