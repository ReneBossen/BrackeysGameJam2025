using Brackeys.Manager;
using UnityEngine;

namespace Brackeys.Robot
{
    public class RobotWaypoint : MonoBehaviour
    {
        [SerializeField]
        private Emplacement _emplacement;
        public Emplacement Emplacement => _emplacement;

        private void Start()
        {
            RobotManager.Instance.Register(this);
        }
    }

    public enum Emplacement
    {
        Entrance,
        Stands,
        SampleStand,
        MoveStand,
        Jail,
        Scene,
        ShootingRange,
        Benches,
        Basketball,
        FerrisWell,
        Toilet,
        Storage
    }
}