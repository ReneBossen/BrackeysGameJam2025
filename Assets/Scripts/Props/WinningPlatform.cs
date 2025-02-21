using Brackeys.Manager;
using Brackeys.Player;
using UnityEngine;

namespace Brackeys.Props
{
    public class WinningPlatform : MonoBehaviour
    {
        private bool _didWin;
        private void OnTriggerEnter(Collider collider)
        {
            if (!collider.TryGetComponent<PlayerController>(out var controller) || _didWin)
            {
                return;
            }

            Debug.Log("[WIN] Player won!");
            controller.ResetPosition();
            VendingMachine.Instance.ResetMachine();
            RobotManager.Instance.ClearAll();
            LevelManager.Instance.ReloadScene();
            _didWin = true;
        }
    }
}