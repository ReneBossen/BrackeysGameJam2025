using Brackeys.Manager;
using Brackeys.Player;
using Brackeys.Player.Interaction;
using Brackeys.VN;
using TMPro;
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

        public void Interact(PlayerController pc)
        {
            _display.ToDisplay = "Hello";
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
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
        }
    }
}