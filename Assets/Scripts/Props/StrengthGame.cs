using System.Collections;
using UnityEngine;

namespace Brackeys.Props
{
    public class StrengthGame : MonoBehaviour
    {
        private bool _isReady = true;

        public bool GetIsReady() => _isReady;

        public void ProcessCollision(ControllerColliderHit other, Vector3 velocity)
        {
            if (!_isReady)
            {
                return;
            }

            CharacterController controller = other.controller;

            Debug.Log($"CharacterController: {controller}");

            if (controller == null)
            {
                return;
            }

            switch (velocity.magnitude)
            {
                case < 2:
                    _isReady = false;
                    StartCoroutine(StartCooldown());
                    break;
                case > 2:
                    Debug.Log($"{other} - Velocity: {velocity.magnitude}");
                    _isReady = false;
                    StartCoroutine(StartCooldown());
                    break;
            }
        }

        private IEnumerator StartCooldown()
        {
            yield return new WaitForSeconds(1);
            _isReady = true;
        }
    }
}