using System.Linq;
using UnityEngine;

namespace Brackeys.Props
{
    public class FollowPath : MonoBehaviour
    {
        [SerializeField] private Transform[] waypoints;

        private int _currentWaypointIndex;
        private int _nextWaypointIndex;

        private bool _isMoving = true;
        private const float _distanceFromWaypoint = 0.5f;


        public void ToggleMove()
        {
            _isMoving = !_isMoving;
        }

        private void Start()
        {
            _currentWaypointIndex = 0;
            _nextWaypointIndex = 1;

            if (!waypoints.Any() || !_isMoving)
            {
                return;
            }

            transform.position = waypoints[_currentWaypointIndex].position;
        }

        private void Update()
        {
            MoveTowardsNextWaypoint();
        }

        private void MoveTowardsNextWaypoint()
        {
            if (!waypoints.Any() || !_isMoving)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, waypoints[_nextWaypointIndex].position,
                4f * Time.deltaTime);

            if (Vector3.Distance(transform.position, waypoints[_nextWaypointIndex].position) < _distanceFromWaypoint)
            {
                UpdateWaypointIndex();
            }
        }

        private void UpdateWaypointIndex()
        {
            _currentWaypointIndex = _nextWaypointIndex;
            _nextWaypointIndex = (_nextWaypointIndex + 1) % waypoints.Length;
        }

        private void OnDrawGizmosSelected()
        {
            if (!waypoints.Any())
            {
                return;
            }

            Gizmos.color = Color.blue;

            for (int i = 0; i < waypoints.Length; i++)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[(i + 1) % waypoints.Length].position);
            }
        }
    }
}