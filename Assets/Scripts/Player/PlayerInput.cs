using Brackeys.Weapons;
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

        //Not Assigned
        private IWeapon _currentWeapon;

        private Camera _cam;

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
            if (_currentWeapon != null)
            {
                _currentWeapon.Fire(_gunEnd.position, _cam.transform.forward);
            }
        }
    }
}