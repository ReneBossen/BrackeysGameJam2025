using UnityEngine;

namespace Brackeys.Props
{
    public class Balloon : MonoBehaviour
    {
        [SerializeField] private float _balloonLiftForce;

        private Rigidbody _rigidbody;
        private SpringJoint _springJoint;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _springJoint = GetComponent<SpringJoint>();
        }
        public void Initialize(Rigidbody connectedBody, float minDistance, float maxDistance)
        {
            _springJoint.connectedBody = connectedBody;
            _springJoint.minDistance = minDistance;
            _springJoint.maxDistance = maxDistance;
        }

        public void ApplyGravity()
        {
            _rigidbody.AddForce(-(Physics.gravity * _balloonLiftForce) * Time.deltaTime);
        }
    }
}