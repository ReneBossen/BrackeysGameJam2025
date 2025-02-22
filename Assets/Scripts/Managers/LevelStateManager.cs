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
        private int _bluePressed;

        [SerializeField]
        private Exit _exit;

        [SerializeField]
        private Animator _openDoor, _openDoor2;

        [SerializeField]
        private Collider _openColl, _openColl2;

        private void Awake()
        {
            Instance = this;

            /*for (int i = 0; i < 3; i++)
            {
                _blueButtons.RemoveAt(Random.Range(0, _blueButtons.Count));
            }
            foreach (var bt in _blueButtons) bt.gameObject.SetActive(false);*/
        }

        public void OpenDoor()
        {
            _openDoor.SetTrigger("Open");
            _openColl.enabled = false;
        }

        private int _triggerCount;
        public void OpenDoorWithTriggers()
        {
            _triggerCount++;
            if (_triggerCount == 2)
            {
                _openDoor2.SetTrigger("Open");
                _openColl2.enabled = false;
            }
        }

        public void IncrBluePressed()
        {
            _bluePressed++;
            if (_bluePressed == 3) _exit.DecreaseValidation();
        }

        public bool IsObjMoveDone => _objMove.IsActivated;
        public bool IsObjMoveMoving => _objMove.IsMoving;
        public bool IsShoot1Done => _objShoot1.IsActivated;
        public bool IsShoot2Done => _objShoot1.IsActivated;

        public bool HasWeaponEquipped => ResourceManager.Instance.PlayerInput.CurrentWeapon != null;
    }
}