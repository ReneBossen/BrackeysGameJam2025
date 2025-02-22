using UnityEngine;
using UnityEngine.UI;

namespace Brackeys.Managers
{
    public class VictoryManager : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            _restartButton.onClick.AddListener(RestartGame);
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void RestartGame()
        {
            LevelManager.Instance.RestartGame();
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}