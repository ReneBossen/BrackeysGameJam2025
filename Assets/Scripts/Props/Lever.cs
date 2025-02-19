using Brackeys.Animations;
using Brackeys.Interfaces;
using Brackeys.Player;
using Brackeys.Player.Interaction;
using UnityEngine;
using UnityEngine.Events;

namespace Brackeys.Props
{
    public class Lever : MonoBehaviour, IInteractable, IShootable
    {
        [SerializeField] private UnityEvent _callbacks;
        public bool CanInteract => true;
        public GameObject GameObject => gameObject;

        private Animator _animator;
        private bool _isOn = false;
        private string _toggle = "Toggle";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Interact(PlayerController pc)
        {
            PullLever();
        }

        public void OnShot()
        {
            PullLever();
        }

        private void PullLever()
        {
            _isOn = !_isOn;
            _animator.SetTrigger(_toggle);
        }

        private void OnLeverDown()
        {
            InvokeCallbacks();
        }

        private void OnLeverUp()
        {
            InvokeCallbacks();
        }

        private void InvokeCallbacks()
        {
            _callbacks.Invoke();
        }
    }
}