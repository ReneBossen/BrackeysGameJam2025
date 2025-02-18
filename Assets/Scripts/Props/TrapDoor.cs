using UnityEngine;

namespace Brackeys.Props
{
    public class TrapDoor : MonoBehaviour
    {
        [SerializeField] private bool _startsOpen;

        private BoxCollider _collider;
        private bool _isOpen;

        private void Start()
        {
            _collider = GetComponent<BoxCollider>();
            _collider.enabled = !_startsOpen;
            _isOpen = !_startsOpen;
        }

        public void Toggle()
        {
            _isOpen = !_isOpen;
            _collider.enabled = _isOpen;
        }
    }
}