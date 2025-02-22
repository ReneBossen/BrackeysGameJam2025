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
            if (!collider.TryGetComponent(out PlayerController controller) || _didWin)
            {
                return;
            }

            if (!VendingMachine.Instance.HasRemainingWeapons())
            {
                Debug.Log("[WINPLATFORM] LOAD VICTORY");
                LevelManager.Instance.LoadVictoryScene();
            }
            else
            {
                controller.ResetPosition();
                VendingMachine.Instance.ResetMachine();
                RobotManager.Instance.ClearAll();
                LevelManager.Instance.ReloadScene();
                _didWin = true;
            }
        }
    }
}