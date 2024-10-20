using UnityEngine.SceneManagement;

namespace TDS.Architecture
{
    public class SceneLoaderService : IService
    {
        #region Public methods

        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        #endregion
    }
}