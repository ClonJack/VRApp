using _Project.Code.GamePlay.EventSystem;
using _Project.Code.Services;
using Cysharp.Threading.Tasks;
using Data.Configs;
using TriInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UnrealTeam.Arena.GameFlow
{
    public class BootScope : LifetimeScope
    {
        [Title("Ref")]
        [SerializeField] 
        private AppConfig _appConfig;

        [SerializeField] 
        private CustomVRUISystem _vruiSystem;
        
        
        protected override void Configure(IContainerBuilder builder) 
            => RegisterEntryPoint(builder);

        private void RegisterEntryPoint(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BootEntryPoint>().AsSelf();
            builder.RegisterBuildCallback(r =>
            {
                BindObjectsToProvider(r);
                ExecuteEntryPoint(r);
            });
        }
        
        private void BindObjectsToProvider(IObjectResolver resolver)
        {
            var objectsProvider = resolver.Resolve<ObjectsProvider>();
            objectsProvider.VrUISystem = _vruiSystem;
        }
        
        private void ExecuteEntryPoint(IObjectResolver resolver)
        {
            var entryPoint = resolver.Resolve<BootEntryPoint>();
            entryPoint.Initialize(_appConfig);
            entryPoint.ExecuteAsync().Forget();
        }
    }
}