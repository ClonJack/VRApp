using _Project.Code.Services;
using Common.Modules.Input;
using Common.Modules.Loading.Classes;
using Common.Modules.Loading.Interfaces;
using UnityEngine.AddressableAssets;
using UnrealTeam.Common.Assets;
using UnrealTeam.Common.Configs;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.GameFlow.Project
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
            builder.Register<InputService>(Lifetime.Singleton).As<IInputService>();

        private void RegisterOther(IContainerBuilder builder)
        {
            builder.Register<ObjectsProvider>(Lifetime.Singleton);
        }
    }

}