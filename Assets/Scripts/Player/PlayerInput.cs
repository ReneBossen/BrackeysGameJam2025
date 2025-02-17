using Brackeys.Weapons;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using InputSystem = Brackeys.Settings.InputSystem.InputSystem;

namespace Brackeys.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private InputSystem _inputSystem;

        [SerializeField]
        private Transform _gunEnd;

        [SerializeField]
        private Transform _handsWeaponTransform;

        private GameObject _weaponModelInstance;
        private IWeapon _currentWeapon;
        public IWeapon CurrentWeapon
        {
            set
            {
                if (_weaponModelInstance != null)
                {
                    Destroy(_weaponModelInstance);
                }
                _currentWeapon = value;
                if (_currentWeapon != null)
                {
                    _weaponModelInstance = Instantiate(_currentWeapon.BaseInfo.WeaponModel, _handsWeaponTransform);
                    _weaponModelInstance.transform.localPosition = Vector3.zero;
                }
            }
            private get => _currentWeapon;
        }

        private Camera _cam;

        private bool _canShoot = true;

        private void Awake()
        {
            _cam = Camera.main;

            _inputSystem = new InputSystem();
            _inputSystem.Player.Fire.performed += OnFire;
            // _inputSystem.Player.Reload.performed += OnReload; // TODO

            var pc = GetComponent<PlayerController>();
            _inputSystem.Player.Move.performed += pc.OnMovement;
            _inputSystem.Player.Move.canceled += pc.OnMovement; // For movements we need to know when we stopped moving too
            _inputSystem.Player.Sprint.performed += pc.OnSprint;
            _inputSystem.Player.Sprint.canceled += pc.OnSprint; // For sprinting we need to know when we stopped sprinting too
            _inputSystem.Player.Jump.performed += pc.OnJump;
            _inputSystem.Player.Look.performed += pc.OnLook;
            _inputSystem.Player.Interact.performed += pc.OnInteract;
        }

        private void OnEnable()
        {
            _inputSystem.Enable();
        }

        private void OnDisable()
        {
            _inputSystem.Disable();
        }

        private void OnFire(InputAction.CallbackContext context)
        {
            if (CurrentWeapon != null && _canShoot)
            {
                CurrentWeapon.Fire(_gunEnd.position, _cam.transform.forward);
                _canShoot = false;
                StartCoroutine(Reload());
            }
        }

        private IEnumerator Reload()
        {
            yield return new WaitForSeconds(CurrentWeapon.BaseInfo.ReloadTime);
            _canShoot = true;
        }
    }
}