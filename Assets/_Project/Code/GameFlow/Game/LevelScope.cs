using Cysharp.Threading.Tasks;
using TriInspector;
using UnityEngine;
using UnrealTeam.VR.GamePlay.Behaviours;
using UnrealTeam.VR.GamePlay.Factory;
using UnrealTeam.VR.Services;
using VContainer;
using VContainer.Unity;

namespace UnrealTeam.VR.GameFlow
{
    public class LevelScope : LifetimeScope
    {
        [SerializeField, Title("Ref")] 
        private Transform _spawnPoint;

        [SerializeField] 
        private KeyboardBehaviour _keyboardBehaviour;
        
        
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
            objectsProvider.KeyboardBehaviour = _keyboardBehaviour;
        }
        
        private void ExecuteEntryPoint(IObjectResolver resolver)
            => resolver.Resolve<LevelEntryPoint>().Execute(this.GetCancellationTokenOnDestroy()).Forget();
    }
}