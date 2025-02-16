using Brackeys.Interfaces;
using Brackeys.Player;
using Brackeys.Player.Interaction;
using System;
using System.Linq;
using UnityEngine;

namespace Brackeys.Props
{
    public class Lever : MonoBehaviour, IInteractable, IShootable
    {
        [SerializeField] private GameObject[] _activateables;
        public bool CanInteract => true;

        private bool _isOn = false;

        private void Start()
        {
            if (_activateables.Length == 0)
            {
                Debug.LogError($"[LVR] {gameObject.name} has no activateables");
            }
            CallActivate();
        }

        public void Interact(PlayerController pc)
        {
            PullLever();
        }

        public void OnShot()
        {
            PullLever();
        }

        public GameObject GameObject => gameObject;

        private void PullLever()
        {
            _isOn = !_isOn;

            int rotationAngle = _isOn ? 30 : -30;
            transform.Rotate(rotationAngle, 0, 0);

            CallActivate();
        }

        private void CallActivate()
        {
            Action<IActivateable> action = _isOn ? x => x.OnActivate() : x => x.OnDeactivate();
            _activateables
                .Select(x => x.GetComponent<IActivateable>())
                .Where(activateable => activateable != null && activateable.CanDeactivate)
                .ToList()
                .ForEach(action);
        }
    }
}