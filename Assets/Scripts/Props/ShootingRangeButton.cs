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

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.isKinematic = true;
        }

        public void OnShot()
        {
            ActivateConnectedObject();
        }

        private void ActivateConnectedObject()
        {
            InvokeCallbacks();

            FollowPath path = GetComponent<FollowPath>();
            _rb.isKinematic = false;
            _rb.linearVelocity = (ResourceManager.Instance.PlayerController.transform.position - transform.position).normalized * 10f;
        }

        private void InvokeCallbacks()
        {
            _callbacks.Invoke();
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