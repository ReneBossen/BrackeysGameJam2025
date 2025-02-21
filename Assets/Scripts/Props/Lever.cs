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
        [SerializeField] private bool _isRequiredToExit;
        public bool CanInteract => true;
        public GameObject GameObject => gameObject;

        private Animator _animator;
        private string _toggle = "Toggle";
        private bool _isPulled = false;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            if (_isRequiredToExit)
            {
                Exit.Instance.AddLever(gameObject);
            }
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
            _isPulled = !_isPulled;

            if (!_isRequiredToExit)
                return;

            if (_isPulled)
            {
                Exit.Instance.DecreaseValidation();
            }
            else
            {
                Exit.Instance.IncreaseValidation();
            }
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