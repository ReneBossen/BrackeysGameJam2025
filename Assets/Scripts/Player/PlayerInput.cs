using Brackeys.Weapons;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using InputSystem = Brackeys.Settings.InputSystem.InputSystem;

namespace Brackeys.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private InputSystem _inputSystem;

        [SerializeField]
        private Transform _gunEnd;

        [SerializeField]
        private Transform _handsWeaponTransformL, _handsWeaponTransformR;

        [SerializeField]
        private Transform _gunModelTransform;

        [SerializeField]
        private Image _aimImage;
        private Sprite _baseSprite;

        [SerializeField]
        private Sprite _energySprite;

        [SerializeField]
        private GameObject _outOfBatteries;

        [SerializeField]
        private Animator _hands;

        private AudioSource _audioSource;
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
                _aimImage.gameObject.SetActive(_currentWeapon != null);
                _hands.gameObject.SetActive(_currentWeapon != null);
                if (_currentWeapon != null)
                {
                    _hands.SetTrigger(CurrentWeapon.BaseInfo.BaseTriggerName);
                    _weaponModelInstance = Instantiate(_currentWeapon.BaseInfo.WeaponModel, CurrentWeapon.BaseInfo.UseRightArm ? _handsWeaponTransformR : _handsWeaponTransformL);
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

            _baseSprite = _aimImage.sprite;

            _aimImage.gameObject.SetActive(false);
            _outOfBatteries.SetActive(false);

            _inputSystem = new InputSystem();
            _inputSystem.Player.Fire.performed += OnFire;
            // _inputSystem.Player.Reload.performed += OnReload; // TODO

            _audioSource = GetComponentInChildren<AudioSource>();

            _pc = GetComponent<PlayerController>();
            _inputSystem.Player.Move.performed += _pc.OnMovement;
            _inputSystem.Player.Move.canceled += _pc.OnMovement; // For movements we need to know when we stopped moving too
            _inputSystem.Player.Sprint.performed += _pc.OnSprint;
            _inputSystem.Player.Sprint.canceled += _pc.OnSprint; // For sprinting we need to know when we stopped sprinting too
            _inputSystem.Player.Jump.performed += _pc.OnJump;
            _inputSystem.Player.Look.performed += _pc.OnLook;
            _inputSystem.Player.Interact.performed += _pc.OnInteract;

            _hands.gameObject.SetActive(false);
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
                bool outOfBatteries = CurrentWeapon.NeedAmmo();

                if (CurrentWeapon.Fire(_gunEnd.position, _cam.transform, _gunModelTransform.position, _pc.Head.rotation))
                {
                    if (CurrentWeapon.BaseInfo.EjectAmmoGameObject)
                    {
                        _ejectionTarget.SetActive(false);
                    }
                    if (CurrentWeapon.BaseInfo.StunDuration > 0f)
                    {
                        _pc.Stun(CurrentWeapon.BaseInfo.StunDuration, CurrentWeapon.BaseInfo.ForceThrowback);
                    }
                    _audioSource.PlayOneShot(CurrentWeapon.BaseInfo.ShootClip);
                }
                _canShoot = false;
                StartCoroutine(Reload(outOfBatteries));
            }
        }

        public void AddAmmo()
        {
            if (CurrentWeapon.AddAmmo())
            {
                _ejectionTarget.SetActive(true);
                _aimImage.sprite = _baseSprite;
            }
        }

        private IEnumerator Reload(bool outOfBatteries)
        {
            _aimImage.color = Color.red;
            if (outOfBatteries) _outOfBatteries.SetActive(true);
            yield return new WaitForSeconds(CurrentWeapon.BaseInfo.ReloadTime);
            if (CurrentWeapon.NeedAmmo()) _aimImage.sprite = _energySprite;
            _outOfBatteries.SetActive(false);
            _canShoot = true;
            _aimImage.color = Color.white;
        }
    }
}