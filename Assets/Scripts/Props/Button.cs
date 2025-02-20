using Brackeys.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Brackeys.Props
{
    public class Button : MonoBehaviour, IShootable
    {
        [SerializeField] private UnityEvent _callbacks;

        [SerializeField] private Material _validationMat;

        public bool IsActivated { private set; get; }
        public bool IsMoving => GetComponent<FollowPath>().enabled;

        public void OnShot()
        {
            ActivateConnectedObject();
            var r = GetComponent<Renderer>();
            var mats = r.materials;
            mats[1] = _validationMat;
            r.materials = mats;
            IsActivated = true;
        }

        private void ActivateConnectedObject()
        {
            if (IsActivated)
                return;

            InvokeCallbacks();

            FollowPath path = GetComponent<FollowPath>();
            if (path != null)
            {
                path.enabled = false;
            }
        }

        private void InvokeCallbacks()
        {
            _callbacks.Invoke();
        }
    }
}