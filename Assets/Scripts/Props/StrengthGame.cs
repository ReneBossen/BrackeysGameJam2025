using System.Collections;
using UnityEngine;

namespace Brackeys.Props
{
    public class StrengthGame : MonoBehaviour
    {
        private bool _isReady = true;
        private Animator _animator;
        private string
            _mark1Trigger = "1mark",
            _mark2Trigger = "2mark",
            _mark3Trigger = "3mark",
            _mark4Trigger = "4mark",
            _mark5Trigger = "5mark",
            _bellTrigger = "bell";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public bool GetIsReady() => _isReady;

        public void ProcessCollision(ControllerColliderHit other, Vector3 velocity)
        {
            if (!_isReady)
            {
                return;
            }

            CharacterController controller = other.controller;

            if (controller == null)
            {
                return;
            }

            switch (velocity.magnitude)
            {
                case < 8:
                    _isReady = false;
                    _animator.SetTrigger(_mark1Trigger);
                    StartCoroutine(StartCooldown());
                    break;
                case < 15:
                    _isReady = false;
                    _animator.SetTrigger(_mark2Trigger);
                    StartCoroutine(StartCooldown());
                    break;
                case < 20:
                    _isReady = false;
                    _animator.SetTrigger(_mark3Trigger);
                    StartCoroutine(StartCooldown());
                    break;
                case < 25:
                    _isReady = false;
                    _animator.SetTrigger(_mark4Trigger);
                    StartCoroutine(StartCooldown());
                    break;
                case < 32:
                    _isReady = false;
                    _animator.SetTrigger(_mark5Trigger);
                    StartCoroutine(StartCooldown());
                    break;
                case >= 32:
                    _isReady = false;
                    _animator.SetTrigger(_bellTrigger);
                    StartCoroutine(StartCooldown());
                    break;
            }
        }

        private void PlayBell()
        {
            // Play bell sound
            Debug.Log("Bell sound played");
        }

        private IEnumerator StartCooldown()
        {
            yield return new WaitForSeconds(2);
            _isReady = true;
        }
    }
}