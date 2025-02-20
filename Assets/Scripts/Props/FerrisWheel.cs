using UnityEngine;

namespace Brackeys.Props
{
    public class FerrisWheel : MonoBehaviour
    {
        [SerializeField]
        private float _torqueSpeed;

        private Rigidbody _rb;

        private bool _isActive;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rb.angularVelocity = new Vector3(0f, 0f, _isActive ? _torqueSpeed : 0f);
        }

        public void ToggleActive()
        {
            _isActive = !_isActive;
        }
    }
}