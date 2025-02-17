using Brackeys.Player.Interaction;
using Brackeys.SO;
using Brackeys.Weapons;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Brackeys.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerInfo _info;

        [SerializeField]
        private Transform _head;
        private float _headRotation;

        [SerializeField]
        private GameObject _pressToInteract;

        private Rigidbody _rb;
        private CharacterController _controller;
        private Headbob _headbob;
        private bool _isSprinting;
        private float _verticalSpeed;

        private Vector2 _mov;
        private Vector3 _startingPos;

        private List<IInteractable> _interactions = new();

        private void Awake()
        {
            _pressToInteract.SetActive(false);
            _rb = GetComponent<Rigidbody>();
            _controller = GetComponent<CharacterController>();
            _headbob = GetComponentInChildren<Headbob>();

            Cursor.lockState = CursorLockMode.Locked;

            var tArea = GetComponentInChildren<TriggerArea>();
            tArea.OnTriggerEnterEvent.AddListener((Collider c) =>
            {
                if (c.TryGetComponent<IInteractable>(out var i))
                {
                    _interactions.Add(i);
                }
            });
            tArea.OnTriggerExitEvent.AddListener((Collider c) =>
            {
                if (c.gameObject.TryGetComponent<IInteractable>(out var i))
                {
                    Unregister(i);
                }
            });

            _startingPos = transform.position;
        }

        public void Unregister(IInteractable i)
        {
            _interactions.RemoveAll(x =>
            {
                try
                {
                    return x.GameObject.GetInstanceID() == i.GameObject.GetInstanceID();
                }
                catch // Unity shitting itself
                {
                    return true;
                }
            });
        }

        public void ResetPosition()
        {
            _controller.enabled = false;
            transform.position = _startingPos;
            SetWeapon(null);
            _controller.enabled = true;
        }

        private void Update()
        {
            var pos = _mov;
            Vector3 desiredMove = transform.forward * pos.y + transform.right * pos.x;

            // Get a normal for the surface that is being touched to move along it
            Physics.SphereCast(transform.position, _controller.radius, Vector3.down, out RaycastHit hitInfo,
                               _controller.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
            desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

            Vector3 moveDir = Vector3.zero;
            moveDir.x = desiredMove.x * _info.ForceMultiplier * (_isSprinting ? _info.SpeedRunningMultiplicator : 1f);
            moveDir.z = desiredMove.z * _info.ForceMultiplier * (_isSprinting ? _info.SpeedRunningMultiplicator : 1f);

            if (_controller.isGrounded && _verticalSpeed < 0f) // We are on the ground and not jumping
            {
                moveDir.y = -.1f; // Stick to the ground
                _verticalSpeed = -_info.GravityMultiplicator;
            }
            else
            {
                // We are currently jumping, reduce our jump velocity by gravity and apply it
                _verticalSpeed += Physics.gravity.y * _info.GravityMultiplicator;
                moveDir.y += _verticalSpeed;
            }

            _controller.Move(moveDir * _info.MovementSpeed * Time.deltaTime);
            if (_info.ApplyHeadbob)
            {
                _headbob.ApplyHeadbob(moveDir, _controller.isGrounded, _isSprinting);
            }

            _pressToInteract.SetActive(_interactions.Any(x => x.CanInteract));
        }

        public void Stun(float stunDuration, float throwForce)
        {
            StartCoroutine(StunCoroutine(stunDuration, throwForce));
        }

        private IEnumerator StunCoroutine(float stunDuration, float throwForce)
        {
            _controller.enabled = false;
            _rb.isKinematic = false;
            _rb.AddForce(-_head.forward * throwForce, ForceMode.Impulse);
            yield return new WaitForSeconds(stunDuration);
            _rb.isKinematic = true;
            _controller.enabled = true;
        }

        public void OnInteract(InputAction.CallbackContext value)
        {
            _interactions.FirstOrDefault(x => x.CanInteract)?.Interact(this);
        }

        public void OnMovement(InputAction.CallbackContext value)
        {
            _mov = value.ReadValue<Vector2>().normalized;
        }

        public void OnLook(InputAction.CallbackContext value)
        {
            var rot = value.ReadValue<Vector2>();

            transform.rotation *= Quaternion.AngleAxis(rot.x * _info.HorizontalLookMultiplier, Vector3.up);

            _headRotation -= rot.y * _info.VerticalLookMultiplier; // Vertical look is inverted by default, hence the -=

            _headRotation = Mathf.Clamp(_headRotation, -89, 89);
            _head.transform.localRotation = Quaternion.AngleAxis(_headRotation, Vector3.right);
        }

        public void OnJump(InputAction.CallbackContext value)
        {
            if (_controller.isGrounded)
            {
                _verticalSpeed = _info.JumpForce;
            }
        }

        public void OnSprint(InputAction.CallbackContext value)
        {
            _isSprinting = value.ReadValueAsButton();
        }

        public void SetWeapon(IWeapon weapon)
        {
            GetComponent<PlayerInput>().CurrentWeapon = weapon;
            Debug.Log("[PLY] Equipped weapon changed");
        }
    }
}