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
        private string _idleDown = "IdleDown";
        private string _pullLever = "PullLever";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _animator.SetBool(_idleDown, false);
            _animator.SetBool(_pullLever, false);
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
            _animator.SetBool(_pullLever, true);
            _animator.Play(_isOn ? AnimationNames.LeverUp : AnimationNames.LeverDown);
        }

        private void OnLeverDown()
        {
            _animator.SetBool(_idleDown, true);
            _animator.SetBool(_pullLever, false);
            InvokeCallbacks();
        }

        private void OnLeverUp()
        {
            _animator.SetBool(_idleDown, false);
            _animator.SetBool(_pullLever, false);
            InvokeCallbacks();
        }

        private void InvokeCallbacks()
        {
            _callbacks.Invoke();
        }
    }
}