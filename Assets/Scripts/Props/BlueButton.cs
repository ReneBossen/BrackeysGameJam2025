using Brackeys.Interfaces;
using Brackeys.Manager;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Brackeys.Props
{
    public class BlueButton : MonoBehaviour, IShootable
    {
        [SerializeField] private Material _validationMat;

        [SerializeField] private UnityEvent _evt;

        public bool IsActivated { private set; get; }
        public bool IsMoving => GetComponent<FollowPath>().enabled;

        private void Start()
        {
        }

        public void OnShot()
        {
            ActivateConnectedObject();
            var r = GetComponent<Renderer>();
            var mats = r.materials;
            mats[1] = _validationMat;
            r.materials = mats;
            IsActivated = true;
        }

        private void ActivateConnectedObject()
        {
            if (IsActivated)
                return;

            //LevelStateManager.Instance.IncrBluePressed();
            _evt.Invoke();

            FollowPath path = GetComponent<FollowPath>();
            if (path != null)
            {
                path.enabled = false;
            }
        }
    }
}