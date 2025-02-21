using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Props
{
    public class Door : MonoBehaviour, IActivateable
    {
        public bool CanActivate { private set; get; } = true;

        private Animator _animator;
        private BoxCollider _collider;
        private string _toggle = "Toggle";

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _collider = GetComponent<BoxCollider>();
        }

        public void OnActivate()
        {
            CanActivate = false;
            Toggle();
        }

        public void Toggle()
        {
            _animator.SetTrigger(_toggle);
            _collider.enabled = !_collider.enabled;
        }
    }
}