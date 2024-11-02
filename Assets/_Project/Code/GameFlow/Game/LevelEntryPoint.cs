using System.Threading;
using _Project.Code.GamePlay.PlayerController.Factory;
using Cysharp.Threading.Tasks;
using UnrealTeam.Common.Configs;

namespace _Project.Code.GameFlow.Game
{
    public class LevelEntryPoint 
    {
        private readonly PlayerFactory _playerFactory;
        private readonly IConfigAccess _configAccess;
        
        
        public LevelEntryPoint(PlayerFactory playerFactory, IConfigAccess configAccess)
        {
            _configAccess = configAccess;
            _playerFactory = playerFactory;
        }

        public async UniTask Execute(CancellationToken cancellationToken)
        {
#if UNITY_EDITOR
            // Требуется для избежания эксепшена из за BootFromAnyScene
            await UniTask.DelayFrame(2, cancellationToken: cancellationToken);
#endif
            var player = await _playerFactory.Create();
            
        }
    }
}