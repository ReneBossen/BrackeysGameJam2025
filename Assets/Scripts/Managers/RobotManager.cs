using Brackeys.Robot;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Brackeys.Manager
{
    public class RobotManager : MonoBehaviour
    {
        public static RobotManager Instance { private set; get; }

        [SerializeField]
        private Transform _playerT;

        private List<RobotWaypoint> _waypoints = new();

        private void Awake()
        {
            Instance = this;
        }

        public void Register(RobotWaypoint waypoint)
        {
            _waypoints.Add(waypoint);
        }

        public Transform PlayerTransform => _playerT;

        public RobotWaypoint GetClosestWaypoint()
        {
            return _waypoints.OrderBy(x => Vector3.Distance(_playerT.position, x.transform.position)).First();
        }
    }
}