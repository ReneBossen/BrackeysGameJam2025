using UnityEngine;

namespace Brackeys.Player.Interaction
{
    public interface IInteractable
    {
        public bool CanInteract { get; }

        public void Interact(PlayerController pc);

        public GameObject GameObject { get; }
    }
}