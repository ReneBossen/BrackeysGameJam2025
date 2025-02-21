using Brackeys.Props;
using NUnit.Framework;
using System.Collections.Generic;
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

        [SerializeField]
        private List<BlueButton> _blueButtons;

        private void Awake()
        {
            Instance = this;

            for (int i = 0; i < 3; i++)
            {
                _blueButtons.RemoveAt(Random.Range(0, _blueButtons.Count));
            }
            foreach (var bt in _blueButtons) bt.gameObject.SetActive(false);
        }

        public bool IsObjMoveDone => _objMove.IsActivated;
        public bool IsObjMoveMoving => _objMove.IsMoving;
        public bool IsShoot1Done => _objShoot1.IsActivated;
        public bool IsShoot2Done => _objShoot1.IsActivated;

        public bool HasWeaponEquipped => ResourceManager.Instance.PlayerInput.CurrentWeapon != null;
    }
}