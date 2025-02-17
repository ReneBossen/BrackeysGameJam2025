using Brackeys.Interfaces;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Brackeys.Props
{
    public class Button : MonoBehaviour, IShootable
    {
        [SerializeField] private UnityEvent _callbacks;
        [SerializeField] private Material _onHitMat;

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

            GetComponentInChildren<Renderer>().material = _onHitMat;
        }

        private void InvokeCallbacks()
        {
            _callbacks.Invoke();
        }
    }
}