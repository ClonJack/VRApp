using Common.Modules.Loading.Interfaces;
using Cysharp.Threading.Tasks;
using Data.Configs;
using UnrealTeam.Common.Configs;

namespace UnrealTeam.Arena.GameFlow
{
    public class BootEntryPoint 
    {
        private readonly IConfigLoader _configLoader;
        private readonly ISceneLoader _sceneLoader;
        private AppConfig _appConfig;


        public BootEntryPoint(
            IConfigLoader configLoader,
            ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _configLoader = configLoader;
        }

        public void Initialize(AppConfig appConfig)
            => _appConfig = appConfig;

        public async UniTask ExecuteAsync()
        {
            
#if UNITY_EDITOR
            // Требуется для корректной работы BootFromAnyScene, так как эдитор отрабатывает позже билда контейнера
            await UniTask.Yield();
#endif
            await LoadConfigsData();
            await LoadTargetScene();
        }
        
        private async UniTask LoadConfigsData()
        {
            _configLoader.SetSingleManually(_appConfig); 
            
            await _configLoader.LoadSingle<PlayerConfig>(_appConfig.PlayerConfig);
        }

        private async UniTask LoadTargetScene() =>
            await _sceneLoader.LoadAsync(_appConfig.LoadScene);
    }
}