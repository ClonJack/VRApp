using Cysharp.Threading.Tasks;
using UnityEngine;
using UnrealTeam.Common.Modules.Configs;
using UnrealTeam.Common.Modules.Loading;
using UnrealTeam.VR.Data.Configs;

namespace UnrealTeam.VR.GameFlow
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
            
            Application.targetFrameRate = _appConfig.TargetFrameRate;
            
            await _configLoader.LoadSingle<PlayerConfig>(_appConfig.PlayerConfig);
        }

        private async UniTask LoadTargetScene() =>
            await _sceneLoader.LoadAsync(_appConfig.LoadScene);
    }
}