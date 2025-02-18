using UnityEngine;

namespace Brackeys.Player
{
    public class Headbob : MonoBehaviour
    {
        [SerializeField] private float _amount = 0.05f;
        [SerializeField] private float _frequency = 30f;
        [SerializeField] private float _smooth = 20f;

        public void ApplyHeadbob(Vector3 dir, bool isGrounded, bool isSprinting)
        {
            if (dir.x == 0 || dir.z == 0 && !isGrounded)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, _smooth / 5 * Time.deltaTime);
                return;
            }

            _amount = isSprinting ? _amount = 0.08f : _amount = 0.05f;

            Vector3 pos = Vector3.zero;
            pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.time * _frequency) * _amount * 1.4f, _smooth * Time.deltaTime);
            pos.x += Mathf.Lerp(pos.x, Mathf.Cos(Time.time * _frequency / 2) * _amount * 1.6f, _smooth * Time.deltaTime);
            transform.localPosition += pos;
        }
    }
}