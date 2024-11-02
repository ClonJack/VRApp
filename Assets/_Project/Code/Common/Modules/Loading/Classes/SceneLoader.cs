using Common.Modules.Loading.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Common.Modules.Loading.Classes
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask LoadAsync(string sceneName)
        {
            if (IsCurrentScene(sceneName))
                return;
            
            await SceneManager.LoadSceneAsync(sceneName);
        }

        public async UniTask ReloadAsync() => 
            await SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        
        private static bool IsCurrentScene(string sceneName) 
            => SceneManager.GetActiveScene().name == sceneName;
    }
}