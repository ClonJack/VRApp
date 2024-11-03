using System.Threading;
using _Project.Code.GamePlay.PlayerController.Factory;
using _Project.Code.Services;
using Cysharp.Threading.Tasks;

namespace _Project.Code.GameFlow.Game
{
    public class LevelEntryPoint 
    {
        private readonly PlayerFactory _playerFactory;
        private readonly ObjectsProvider _objectsProvider;


        public LevelEntryPoint(PlayerFactory playerFactory,ObjectsProvider objectsProvider)
        {
            _playerFactory = playerFactory;
            _objectsProvider = objectsProvider;
        }

        public async UniTask Execute(CancellationToken cancellationToken)
        {
#if UNITY_EDITOR
            // Требуется для избежания эксепшена из за BootFromAnyScene
            await UniTask.DelayFrame(2, cancellationToken: cancellationToken);
#endif
            var player = await _playerFactory.Create();
            
            _objectsProvider.KeyboardBehaviour.gameObject.SetActive(true);
            
        }
    }
}