using System;
using UnityEngine;
using UnityEngine.InputSystem;
using InputSystem = Brackeys.Settings.InputSystem.InputSystem;

namespace Brackeys.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private InputSystem _inputSystem;

        private void Awake()
        {
            _inputSystem = new InputSystem();
            _inputSystem.Player.Fire.performed += OnFire;
            _inputSystem.Player.Reload.performed += OnReload;
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
            Debug.Log("Player Fired");
        }

        private void OnReload(InputAction.CallbackContext context)
        {
            Debug.Log("Player Reloaded");
        }
    }
}