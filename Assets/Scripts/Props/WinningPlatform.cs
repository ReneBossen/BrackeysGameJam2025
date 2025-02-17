using Brackeys.Player;
using UnityEngine;

namespace Brackeys.Props
{
    public class WinningPlatform : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (!collider.TryGetComponent<PlayerController>(out var controller))
            {
                return;
            }

            Debug.Log("[WIN] Player won!");
            controller.ResetPosition();
            VendingMachine.Instance.CanInteract = true;
            LevelManager.Instance.ReloadScene();
        }
    }
}