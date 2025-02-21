using Brackeys.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Brackeys.Props
{
    public class Button : MonoBehaviour, IShootable
    {
        [SerializeField] private UnityEvent _callbacks;

        [SerializeField] private Material _validationMat;

        [SerializeField] private bool _isRequiredToExit;

        public bool IsActivated { private set; get; }
        public bool IsMoving => GetComponent<FollowPath>().enabled;

        private void Start()
        {
            if (_isRequiredToExit)
            {
                Exit.Instance.AddLever(gameObject);
            }
        }

        public void OnShot()
        {
            ActivateConnectedObject();
            var r = GetComponent<Renderer>();
            var mats = r.materials;
            mats[1] = _validationMat;
            r.materials = mats;
            IsActivated = true;

            if (!_isRequiredToExit)
                return;

            Exit.Instance.DecreaseValidation();
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
            Debug.Log("clicked");
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