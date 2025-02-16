using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Props
{
    public class Button : MonoBehaviour, IShootable
    {
        [SerializeField] private GameObject _connectedObject;

        public void OnShot()
        {
            Debug.Log("ButtonShot");
            ActivateConnectedObject();
        }

        private void ActivateConnectedObject()
        {
            _connectedObject.TryGetComponent<IActivateable>(out IActivateable component);
            component?.OnActivate();
        }
    }
}