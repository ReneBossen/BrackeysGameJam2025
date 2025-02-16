namespace Brackeys.SceneLoader
{
    public static class SceneLoader
    {
        public static void LoadScene(SceneName scene)
        {
            string sceneName = scene.ToString();

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}