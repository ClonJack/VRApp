using Cysharp.Threading.Tasks;

namespace Common.Modules.Loading.Interfaces
{
    public interface ISceneLoader
    {
        public UniTask LoadAsync(string sceneName);
        public UniTask ReloadAsync();
    }
}