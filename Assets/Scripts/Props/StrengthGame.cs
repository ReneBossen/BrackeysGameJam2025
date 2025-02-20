using System.Collections;
using UnityEngine;

namespace Brackeys.Props
{
    public class StrengthGame : MonoBehaviour
    {
        private CharacterController _characterController;
        private Rigidbody _rigidbody;
        private Vector3 _velocity;
        private bool _isReady = true;

        private void OnTriggerEnter(Collider collider)
        {
            if (!_isReady)
            {
                return;
            }

            GameObject collidedObject = collider.gameObject;

            collidedObject.TryGetComponent<CharacterController>(out _characterController);
            if (_characterController != null)
            {
                _velocity = _characterController.velocity;
            }

            switch (_velocity.magnitude)
            {
                case < 2:
                    return;
                case > 2:
                    Debug.Log($"{collider} - Velocity: {_velocity.magnitude}");
                    break;
            }

            _isReady = false;
            StartCoroutine(StartCooldown());
        }

        private IEnumerator StartCooldown()
        {
            yield return new WaitForSeconds(1);
            _isReady = true;
        }
    }
}