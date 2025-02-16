using Brackeys.Interfaces;
using UnityEngine;

namespace Brackeys.Props
{
    public class TrapDoor : MonoBehaviour, IActivateable
    {
        public bool CanActivate { get; } = true;
        public bool CanDeactivate { get; } = true;

        public void OnActivate()
        {
            gameObject.SetActive(true);
        }

        public void OnDeactivate()
        {
            gameObject.SetActive(false);
        }
    }
}