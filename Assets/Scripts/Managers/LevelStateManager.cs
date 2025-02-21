using Brackeys.Props;
using UnityEngine;

namespace Brackeys.Manager
{
    public class LevelStateManager : MonoBehaviour
    {
        public static LevelStateManager Instance { private set; get; }

        [SerializeField]
        private Button _objMove;

        [SerializeField]
        private ShootingRangeButton _objShoot1, _objShoot2;

        [SerializeField]
        private Lever _objShootEnable;

        private void Awake()
        {
            Instance = this;
        }

        public bool IsObjMoveDone => _objMove.IsActivated;
        public bool IsObjMoveMoving => _objMove.IsMoving;
        public bool IsShoot1Done => _objShoot1.IsActivated;
        public bool IsShoot2Done => _objShoot1.IsActivated;

        public bool HasWeaponEquipped => ResourceManager.Instance.PlayerInput.CurrentWeapon != null;
    }
}