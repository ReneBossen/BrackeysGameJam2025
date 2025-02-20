using UnityEngine;

namespace Brackeys.Props
{
    public class WheelCab : MonoBehaviour
    {
        [SerializeField]
        private Transform _targetAnchor;

        private Vector3 _diff;

        private void Awake()
        {
            _diff = transform.position - _targetAnchor.position;
        }

        private void Update()
        {
            transform.position = _targetAnchor.position - _diff;
        }
    }
}