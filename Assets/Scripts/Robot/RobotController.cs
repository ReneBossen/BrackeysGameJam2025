using Brackeys.Manager;
using UnityEngine;

namespace Brakeys.Robot
{
    public class RobotController : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            var target = RobotManager.Instance.GetClosestWaypoint();

            if (Vector3.Distance(transform.position, target.transform.position) < .1f)
            {
                _rb.linearVelocity = Vector3.zero;
            }
            else
            {
                _rb.linearVelocity = (target.transform.position - transform.position).normalized * _speed;
            }
        }
    }
}