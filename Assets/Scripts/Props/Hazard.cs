using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Props
{
    public class Hazard : MonoBehaviour, IActivateable
    {
        public bool CanActivate { private set; get; }
        private Animator _animator;

        private bool _isOn = false;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            CanActivate = true;
        }

        public void OnActivate()
        {
            _isOn = !_isOn;
            transform.position = new Vector3(transform.position.x, _isOn ? 0f : -1f, transform.position.z);
        }
    }
}