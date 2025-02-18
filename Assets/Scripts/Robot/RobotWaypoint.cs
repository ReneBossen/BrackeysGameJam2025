using Brackeys.Manager;
using UnityEngine;

namespace Brackeys.Robot
{
    public class RobotWaypoint : MonoBehaviour
    {
        private void Start()
        {
            RobotManager.Instance.Register(this);
        }
    }
}