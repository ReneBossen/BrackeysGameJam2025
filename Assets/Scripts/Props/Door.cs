using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Props
{
    public class Door : MonoBehaviour, IActivateable
    {
        public bool CanActivate { private set; get; } = true;

        [SerializeField] private bool _appears;

        private void Start()
        {
            gameObject.SetActive(!_appears);
        }

        public void OnActivate()
        {
            CanActivate = false;

            gameObject.SetActive(_appears);
        }
    }
}