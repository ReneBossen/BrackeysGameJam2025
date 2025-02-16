using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Props
{
    public class Button : MonoBehaviour, IShootable
    {
        [SerializeField] private GameObject _connectedObject;

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
        }
    }
}