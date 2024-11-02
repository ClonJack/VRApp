using _Project.Code.GamePlay.PlayerController.Factory;
using _Project.Code.Services;
using Cysharp.Threading.Tasks;
using TriInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.GameFlow.Game
{
    public class LevelScope : LifetimeScope
    {
        [Title("Ref")]
        [SerializeField] private Transform _spawnPoint;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterEntryPoint(builder);
            RegisterFactories(builder);
        }
        
        private void RegisterEntryPoint(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LevelEntryPoint>().AsSelf();
            builder.RegisterBuildCallback(resolver =>
            {
                BindObjectsToProvider(resolver);
                ExecuteEntryPoint(resolver);
            });
        }

        private void RegisterFactories(IContainerBuilder builder)
        {
            builder.Register<PlayerFactory>(Lifetime.Singleton);
        }
        
        private void BindObjectsToProvider(IObjectResolver resolver)
        {
            var objectsProvider = resolver.Resolve<ObjectsProvider>();
            objectsProvider.SpawnPoint = _spawnPoint;
        }
        
        private void ExecuteEntryPoint(IObjectResolver resolver)
            => resolver.Resolve<LevelEntryPoint>().Execute(this.GetCancellationTokenOnDestroy()).Forget();
    }
}