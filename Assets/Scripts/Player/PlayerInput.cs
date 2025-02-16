using Brackeys.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;
using InputSystem = Brackeys.Settings.InputSystem.InputSystem;

namespace Brackeys.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private InputSystem _inputSystem;

        //Not Assigned
        private IWeapon _currentWeapon;

        private void Awake()
        {
            _inputSystem = new InputSystem();
            _inputSystem.Player.Fire.performed += OnFire;
            _inputSystem.Player.Reload.performed += OnReload;

            var pc = GetComponent<PlayerController>();
            _inputSystem.Player.Move.performed += pc.OnMovement;
            _inputSystem.Player.Move.canceled += pc.OnMovement; // For movements we need to know when we stopped moving too
            _inputSystem.Player.Sprint.performed += pc.OnSprint;
            _inputSystem.Player.Jump.performed += pc.OnJump;
            _inputSystem.Player.Look.performed += pc.OnLook;
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
            if (_currentWeapon != null)
            {
                _currentWeapon.Fire();
            }
        }

        private void OnReload(InputAction.CallbackContext context)
        {
            //_currentWeapon.Reload();
        }
    }
}