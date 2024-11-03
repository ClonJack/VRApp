using _Project.Code.Services;
using Cysharp.Threading.Tasks;
using Data.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnrealTeam.Common.Assets;
using UnrealTeam.Common.Configs;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.GamePlay.PlayerController.Factory
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