using Brackeys.Player.Interaction;
using UnityEngine;

namespace Brackeys.Props
{
    public class PopcornMachine : MonoBehaviour
    {
        private Animator _animator;
        private string _toggle = "Toggle";
        private bool _lidIsOpen = false;
        [SerializeField] private BoxCollider _lidCollider;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Toggle()
        {
            _animator.SetTrigger(_toggle);
            _lidCollider.enabled = _lidIsOpen;
            _lidIsOpen = !_lidIsOpen;
        }
    }
}