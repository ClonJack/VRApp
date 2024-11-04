using UnityEngine.AddressableAssets;
using UnrealTeam.Common.Modules.Assets;
using UnrealTeam.Common.Modules.Configs;
using UnrealTeam.Common.Modules.Loading;
using UnrealTeam.VR.Services;
using UnrealTeam.VR.Services.Input;
using VContainer;
using VContainer.Unity;

namespace UnrealTeam.VR.GameFlow
{
    public class ProjectScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterLoading(builder);
            RegisterAsset(builder);
            RegisterConfig(builder);
            RegisterInput(builder);
            RegisterOther(builder);
        }
        
        private void RegisterLoading(IContainerBuilder builder) =>
            builder.Register<SceneLoader>(Lifetime.Singleton).As<ISceneLoader>();

        private void RegisterAsset(IContainerBuilder builder) =>
            builder.Register<AddressableAssetProvider>(Lifetime.Singleton).As<IAssetProvider<AssetReference>>();

        private void RegisterConfig(IContainerBuilder builder) =>
            builder.Register<ConfigProvider>(Lifetime.Singleton).As<IConfigLoader, IConfigAccess>();

        private void RegisterInput(IContainerBuilder builder) => 
            builder.RegisterEntryPoint<InputService>().As<IInputService>();

        private void RegisterOther(IContainerBuilder builder)
        {
            builder.Register<ObjectsProvider>(Lifetime.Singleton);
        }
    }
}