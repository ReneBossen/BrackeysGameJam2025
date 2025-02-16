using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Props
{
    public class Button : MonoBehaviour, IShootable
    {
        [SerializeField] private GameObject _connectedObject;
        [SerializeField] private Material _onHitMat;

        private void Start()
        {
            if (_connectedObject == null)
            {
                Debug.LogError($"[BTN] {gameObject.name} has no connectedObject");
            }
        }

        public void OnShot()
        {
            ActivateConnectedObject();
        }

        private void ActivateConnectedObject()
        {
            _connectedObject.TryGetComponent<IActivateable>(out IActivateable component);
            if (component.CanActivate)
            {
                component?.OnActivate();
            }

            var path = GetComponent<FollowPath>();
            if (path != null)
            {
                path.enabled = false;
            }
            GetComponentInChildren<Renderer>().material = _onHitMat;
        }
    }
}