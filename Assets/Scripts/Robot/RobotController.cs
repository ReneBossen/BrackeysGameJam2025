using Brackeys.Manager;
using Brackeys.Player;
using Brackeys.Player.Interaction;
using Brackeys.Robot;
using Brackeys.Translation;
using Brackeys.VN;
using UnityEngine;

namespace Brakeys.Robot
{
    public class RobotController : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private TextDisplay _display;

        private Rigidbody _rb;

        public bool CanInteract => true;

        public GameObject GameObject => gameObject;

        private RobotWaypoint _targetWaypoint;

        private Animator _anim;

        private bool _didSpeak;

        public void Interact(PlayerController pc)
        {
            _display.ToDisplay = Translate.Instance.Tr(
                _targetWaypoint.Emplacement switch
                {
                    Emplacement.Entrance when LevelStateManager.Instance.HasWeaponEquipped && !_didSpeak => "robot_entrance_hasWeaponFirstTime",
                    Emplacement.Entrance when LevelStateManager.Instance.HasWeaponEquipped => "robot_entrance_hasWeaponNormal",
                    Emplacement.Entrance => "robot_entrance_noWeapon",
                    
                    Emplacement.Stands => "robot_stands_normal",
                    
                    Emplacement.SampleStand => "robot_sampleStand_normal",

                    Emplacement.MoveStand when LevelStateManager.Instance.IsObjMoveDone => "robot_moveStand_complete",
                    Emplacement.MoveStand when LevelStateManager.Instance.IsObjMoveMoving => "robot_moveStand_moving",
                    Emplacement.MoveStand => "robot_moveStand_notMoving",

                    Emplacement.Jail => "robot_jail_normal",

                    Emplacement.Scene => "robot_scene_normal",

                    Emplacement.ShootingRange when LevelStateManager.Instance.IsShoot1Done && LevelStateManager.Instance.IsShoot2Done => "robot_shooting_2done",
                    Emplacement.ShootingRange when LevelStateManager.Instance.IsShoot1Done || LevelStateManager.Instance.IsShoot2Done => "robot_shooting_1done",
                    Emplacement.ShootingRange => "robot_shooting_none",

                    Emplacement.Benches => "robot_benches_normal",

                    Emplacement.Basketball => "robot_basketball_normal",

                    Emplacement.FerrisWell => "robot_ferrisWheel_normal",

                    Emplacement.Toilet => "robot_toilet_normal",

                    Emplacement.Storage => "robot_storage_normal",

                    _ => throw new System.NotImplementedException()
                }
            );
            _didSpeak = true;
            _anim.SetBool("IsSpeaking", true);
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _display.ToDisplay = null;

            _anim = GetComponent<Animator>();
            _display.OnDone.AddListener(() =>
            {
                _anim.SetBool("IsSpeaking", false);
            });
        }

        private void Update()
        {
            var target = RobotManager.Instance.GetClosestWaypoint();
            if (target == null)
            {
                _rb.linearVelocity = Vector3.zero;
                return;
            }

            if (Vector3.Distance(transform.position, target.transform.position) < .1f)
            {
                _rb.linearVelocity = Vector3.zero;
            }
            else
            {
                _rb.linearVelocity = (target.transform.position - transform.position).normalized * _speed;
            }
            transform.LookAt(RobotManager.Instance.PlayerTransform, Vector3.up);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
            _targetWaypoint = target;
        }
    }
}