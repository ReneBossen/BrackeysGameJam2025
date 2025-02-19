using UnityEngine;

namespace Brackeys.Props
{
    public class TrapDoor : MonoBehaviour
    {
        [SerializeField] private bool _startsOpen;

        private BoxCollider _collider;
        private bool _isOpen;
        private Animator _animator;

        private string _toggle = "Toggle";
        private string _doorStaysOpen = "DoorStaysOpen";
        private bool _isDoorOpen = false;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            if (_startsOpen)
            {
                _animator.SetTrigger("StartOpen");
                _isDoorOpen = true;
            }

            _collider = GetComponentInChildren<BoxCollider>();
            _collider.enabled = !_startsOpen;
            _isOpen = !_startsOpen;
        }

        public void Toggle()
        {
            _isOpen = !_isOpen;
            _collider.enabled = _isOpen;

            PlayAnimation();
        }

        private void PlayAnimation()
        {
            _animator.SetTrigger(_toggle);
            _isDoorOpen = !_isDoorOpen;
            _animator.SetBool(_doorStaysOpen, _isDoorOpen);
        }
    }
}