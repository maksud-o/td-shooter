using UnityEngine.SceneManagement;

namespace TDS.Architecture.Services
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