using Brackeys.Manager;
using Brackeys.SceneLoader;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Brackeys
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { private set; get; }

        private void Awake()
        {
            Instance = this;
            if (!SceneManager.GetAllScenes().Any(x => x.buildIndex == (int)SceneName.Hall)) // Debug helper
            {
                SceneManager.LoadScene((int)SceneName.Hall, LoadSceneMode.Additive);
            }
        }

        public void ReloadScene()
        {
            StartCoroutine(ReloadSceneCoroutine());
        }
        private IEnumerator ReloadSceneCoroutine()
        {
            yield return SceneManager.UnloadSceneAsync((int)SceneName.Hall);
            yield return Resources.UnloadUnusedAssets();
            yield return SceneManager.LoadSceneAsync((int)SceneName.Hall, LoadSceneMode.Additive);
            ResourceManager.Instance.PlayerController.ReadyUpPlayer();
        }
    }
}