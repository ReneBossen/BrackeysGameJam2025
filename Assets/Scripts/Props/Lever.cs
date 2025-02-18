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

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _animator.SetBool("IdleDown", false);
            _animator.SetBool("PullLever", false);
        }

        public void Interact(PlayerController pc)
        {
            _animator.SetBool("PullLever", true);
            PullLever();
        }

        public void OnShot()
        {
            _animator.SetBool("PullLever", true);
            PullLever();
        }

        private void PullLever()
        {
            _isOn = !_isOn;
            _animator.Play(_isOn ? AnimationNames.LeverUp : AnimationNames.LeverDown);
        }

        private void OnLeverDown()
        {
            _animator.SetBool("IdleDown", true);
            _animator.SetBool("PullLever", false);
            InvokeCallbacks();
        }

        private void OnLeverUp()
        {
            _animator.SetBool("IdleDown", false);
            _animator.SetBool("PullLever", false);
            InvokeCallbacks();
        }

        private void InvokeCallbacks()
        {
            _callbacks.Invoke();
        }
    }
}