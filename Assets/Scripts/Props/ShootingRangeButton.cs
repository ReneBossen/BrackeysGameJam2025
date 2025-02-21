using Brackeys.Interfaces;
using Brackeys.Manager;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Brackeys.Props
{
    [RequireComponent(typeof(Rigidbody))]
    public class ShootingRangeButton : MonoBehaviour, IShootable
    {
        [SerializeField] private UnityEvent _callbacks;
        [SerializeField] private ShootingGallery _shootingGallery;
        [SerializeField] private bool _isRequiredToExit;

        private Rigidbody _rb;

        public bool IsActivated { private set; get; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.isKinematic = true;
        }

        public void InitShootingRangeButton()
        {
            if (_isRequiredToExit)
            {
                Exit.Instance.AddRequiredObject(gameObject);
            }
        }

        public void OnShot()
        {
            if (!_shootingGallery.IsActive)
            {
                return;
            }

            ActivateConnectedObject();

            if (!_isRequiredToExit)
                return;

            Exit.Instance.DecreaseValidation();
        }

        private void ActivateConnectedObject()
        {
            InvokeCallbacks();

            FollowPath path = GetComponent<FollowPath>();
            _rb.isKinematic = false;
            _rb.linearVelocity = (transform.position - ResourceManager.Instance.PlayerController.transform.position).normalized * 10f;
        }

        private void InvokeCallbacks()
        {
            if (!IsActivated)
                _callbacks.Invoke();
            IsActivated = true;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            for (int i = 0; i < _callbacks.GetPersistentEventCount(); i++)
            {
                Gizmos.DrawLine(_callbacks.GetPersistentTarget(i).GameObject().gameObject.transform.position, transform.position);
            }
        }
    }
}