using Brackeys.Animations;
using Brackeys.Interfaces;
using Brackeys.Player;
using Brackeys.Player.Interaction;
using Unity.VisualScripting;
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
            _animator.SetTrigger(_toggle);
        }

        private void InvokeCallbacks()
        {
            _callbacks.Invoke();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            for (int i = 0; i < _callbacks.GetPersistentEventCount(); i++)
            {
                Gizmos.DrawLine(_callbacks.GetPersistentTarget(i).GameObject().gameObject.transform.position, transform.position);
            }
        }
    }
}