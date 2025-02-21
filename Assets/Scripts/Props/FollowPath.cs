using System.Linq;
using UnityEngine;

namespace Brackeys.Props
{
    public class FollowPath : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private Transform[] _waypoints;

        private int _currentWaypointIndex;
        private int _nextWaypointIndex;

        private bool _isMoving = true;
        private const float _distanceFromWaypoint = 0.1f;


        public void ToggleMove()
        {
            _isMoving = !_isMoving;
        }

        private void Start()
        {
            _currentWaypointIndex = 0;
            _nextWaypointIndex = 1;

            if (!_waypoints.Any() || !_isMoving)
            {
                return;
            }

            transform.position = _waypoints[_currentWaypointIndex].position;
        }

        private void Update()
        {
            MoveTowardsNextWaypoint();
        }

        private void MoveTowardsNextWaypoint()
        {
            if (!_waypoints.Any() || !_isMoving)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, _waypoints[_nextWaypointIndex].position,
                _movementSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _waypoints[_nextWaypointIndex].position) < _distanceFromWaypoint)
            {
                UpdateWaypointIndex();
            }
        }

        private void UpdateWaypointIndex()
        {
            _currentWaypointIndex = _nextWaypointIndex;
            _nextWaypointIndex = (_nextWaypointIndex + 1) % _waypoints.Length;
        }

        private void OnDrawGizmosSelected()
        {
            if (!_waypoints.Any())
            {
                return;
            }

            Gizmos.color = Color.blue;

            for (int i = 0; i < _waypoints.Length; i++)
            {
                Gizmos.DrawLine(_waypoints[i].position, _waypoints[(i + 1) % _waypoints.Length].position);
            }
        }
    }
}