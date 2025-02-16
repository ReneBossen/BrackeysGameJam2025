using Brackeys.Player;
using Brackeys.SceneLoader;
using UnityEngine;

namespace Brackeys.Props
{
    public class WinningPlatform : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            collider.TryGetComponent<PlayerController>(out PlayerController controller);

            if (controller == null)
            {
                return;
            }

            Debug.Log("[WIN] Player won!");
            SceneLoader.SceneLoader.LoadScene(SceneName.Game);
        }
    }
}