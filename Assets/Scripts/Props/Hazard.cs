using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Props
{
    public class Hazard : MonoBehaviour, IActivateable
    {
        public bool CanActivate { private set; get; }
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            CanActivate = true;
        }

        public void OnActivate()
        {
            _animator.Play("HazardActive");
        }
    }
}