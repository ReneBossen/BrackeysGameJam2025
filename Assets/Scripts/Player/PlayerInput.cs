using Brackeys.Weapons;
using System.Collections;
using System.Linq;
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

        [SerializeField]
        private Transform _gunModelTransform;

        private GameObject _weaponModelInstance;
        private GameObject _ejectionTarget;
        private PlayerController _pc;
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
                    _ejectionTarget = _weaponModelInstance.GetComponentsInChildren<MeshRenderer>().FirstOrDefault(x => x.CompareTag("GunEffectTarget"))?.gameObject;
                }
            }
            get => _currentWeapon;
        }

        private Camera _cam;

        private bool _canShoot = true;

        private void Awake()
        {
            _cam = Camera.main;

            _inputSystem = new InputSystem();
            _inputSystem.Player.Fire.performed += OnFire;
            // _inputSystem.Player.Reload.performed += OnReload; // TODO

            _pc = GetComponent<PlayerController>();
            _inputSystem.Player.Move.performed += _pc.OnMovement;
            _inputSystem.Player.Move.canceled += _pc.OnMovement; // For movements we need to know when we stopped moving too
            _inputSystem.Player.Sprint.performed += _pc.OnSprint;
            _inputSystem.Player.Sprint.canceled += _pc.OnSprint; // For sprinting we need to know when we stopped sprinting too
            _inputSystem.Player.Jump.performed += _pc.OnJump;
            _inputSystem.Player.Look.performed += _pc.OnLook;
            _inputSystem.Player.Interact.performed += _pc.OnInteract;
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
                CurrentWeapon.Fire(_gunEnd.position, _cam.transform.forward, _gunModelTransform.position, _pc.Head.rotation);
                if (CurrentWeapon.BaseInfo.EjectAmmoGameObject)
                {
                    _ejectionTarget.SetActive(false);
                }
                if (CurrentWeapon.BaseInfo.StunDuration > 0f)
                {
                    _pc.Stun(CurrentWeapon.BaseInfo.StunDuration, CurrentWeapon.BaseInfo.ForceThrowback);
                }
                _canShoot = false;
                StartCoroutine(Reload());
            }
        }

        public void AddAmmo()
        {
            if (CurrentWeapon.AddAmmo())
            {
                _ejectionTarget.SetActive(true);
            }
        }

        private IEnumerator Reload()
        {
            yield return new WaitForSeconds(CurrentWeapon.BaseInfo.ReloadTime);
            _canShoot = true;
        }
    }
}