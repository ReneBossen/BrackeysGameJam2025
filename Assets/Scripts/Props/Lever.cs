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

        private bool _isOn = false;

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

            int rotationAngle = _isOn ? 30 : -30;
            transform.Rotate(rotationAngle, 0, 0);

            InvokeCallbacks();
        }

        private void InvokeCallbacks()
        {
            _callbacks.Invoke();
        }
    }
}