using Cysharp.Threading.Tasks;
using TriInspector;
using UnityEngine;
using UnrealTeam.VR.Data.Configs;
using UnrealTeam.VR.GamePlay;
using UnrealTeam.VR.Services;
using VContainer;
using VContainer.Unity;

namespace UnrealTeam.VR.GameFlow
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