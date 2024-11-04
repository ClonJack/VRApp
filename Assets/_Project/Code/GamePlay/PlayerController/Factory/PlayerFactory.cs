using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnrealTeam.Common.Modules.Assets;
using UnrealTeam.Common.Modules.Configs;
using UnrealTeam.VR.Data.Configs;
using UnrealTeam.VR.GamePlay.Behaviours;
using UnrealTeam.VR.Services;
using VContainer;
using VContainer.Unity;

namespace UnrealTeam.VR.GamePlay.Factory
{
    public class PlayerFactory
    {
        private readonly IConfigAccess _configAccess;
        private readonly ObjectsProvider _objectsProvider;
        private readonly IObjectResolver _objectResolver;
        private readonly IAssetProvider<AssetReference> _assetProvider;

        
        public PlayerFactory(
            IConfigAccess configAccess, 
            ObjectsProvider objectsProvider,
            IObjectResolver objectResolver,
            IAssetProvider<AssetReference> assetProvider)
        {
            _configAccess = configAccess;
            _objectsProvider = objectsProvider;
            _objectResolver = objectResolver;
            _assetProvider = assetProvider;
        }
        
        public async UniTask<PlayerBehaviour> Create()
        {
            var playerConfig = _configAccess.GetSingle<PlayerConfig>();
            
            var playerPrefab = await _assetProvider.Load<GameObject>(playerConfig.PlayerRef); 
            
            var playerInstance = _objectResolver.Instantiate(playerPrefab,
                _objectsProvider.SpawnPoint.position, _objectsProvider.SpawnPoint.rotation);
            
            var player = playerInstance.GetComponent<PlayerBehaviour>();
            
            _objectsProvider.PlayerBehaviour = player;
            
            return player;
        }
    }
}