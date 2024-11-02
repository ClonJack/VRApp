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
        [Title("App")]
        [SerializeField] private AppConfig _appConfig;
        
        
        protected override void Configure(IContainerBuilder builder) 
            => RegisterEntryPoint(builder);

        private void RegisterEntryPoint(IContainerBuilder builder)
        {
            builder.Register<BootEntryPoint>(Lifetime.Singleton);
            builder.RegisterBuildCallback(ExecuteEntryPoint);
        }
        
        private void ExecuteEntryPoint(IObjectResolver resolver)
        {
            var entryPoint = resolver.Resolve<BootEntryPoint>();
            entryPoint.Initialize(_appConfig);
            entryPoint.ExecuteAsync().Forget();
        }
    }
}