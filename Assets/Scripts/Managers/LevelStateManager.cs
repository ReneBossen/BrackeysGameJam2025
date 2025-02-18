using Brackeys.Props;
using UnityEngine;

namespace Brackeys.Manager
{
    public class LevelStateManager : MonoBehaviour
    {
        public static LevelStateManager Instance { private set; get; }

        [SerializeField]
        private Button _objMove, _objGlass;

        private void Awake()
        {
            Instance = this;
        }

        public bool IsObjMoveDone => _objMove.IsActivated;
        public bool IsObjMoveMoving => _objMove.IsMoving;
        public bool IsObjGlassDone => _objGlass.IsActivated;

        public bool HasWeaponEquipped => ResourceManager.Instance.PlayerInput.CurrentWeapon != null;
    }
}