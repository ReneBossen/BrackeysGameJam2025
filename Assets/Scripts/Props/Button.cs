using Brackeys.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Brackeys.Props
{
    public class Button : MonoBehaviour, IShootable
    {
        [SerializeField] private UnityEvent _callbacks;

        public void OnShot()
        {
            ActivateConnectedObject();
        }

        private void ActivateConnectedObject()
        {
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