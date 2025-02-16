using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Props
{
    public class Door : MonoBehaviour, IActivateable
    {
        public bool CanActivate { private set; get; } = true;
        public bool CanDeactivate { get; } = false;

        public void OnActivate()
        {
            CanActivate = false;

            gameObject.SetActive(false);
        }
    }
}