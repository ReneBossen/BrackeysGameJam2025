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

        public void Interact(PlayerController pc)
        {
            _display.ToDisplay = Translate.Instance.Tr(
                _targetWaypoint.Emplacement switch
                {
                    Emplacement.Dispenser when LevelStateManager.Instance.HasWeaponEquipped => "robot_dispenser_weaponTaken",
                    Emplacement.Dispenser => "robot_dispenser_pendingWeapon",

                    Emplacement.ButtonMove when !LevelStateManager.Instance.HasWeaponEquipped => "robot_button_needWeapon",
                    Emplacement.ButtonMove when LevelStateManager.Instance.IsObjMoveDone => "robot_buttonMove_done",
                    Emplacement.ButtonMove when LevelStateManager.Instance.IsObjMoveMoving => "robot_buttonMove_notDoneMoving",
                    Emplacement.ButtonMove => "robot_buttonMove_notDoneNotMoving",

                    _ => throw new System.NotImplementedException()
                }
            );
            _anim.SetBool("IsSpeaking", true);
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _display.ToDisplay = null;

            _anim = GetComponent<Animator>();
            _display.OnDone.AddListener(() =>
            {
                Debug.Log("done");
                _anim.SetBool("IsSpeaking", false);
            });
        }

        private void Update()
        {
            var target = RobotManager.Instance.GetClosestWaypoint();

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