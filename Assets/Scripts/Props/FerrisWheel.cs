using UnityEngine;

namespace Brackeys.Props
{
    public class FerrisWheel : MonoBehaviour
    {
        [SerializeField]
        private float _torqueSpeed;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rb.angularVelocity = new Vector3(0f, 0f, _torqueSpeed);
        }
    }
}