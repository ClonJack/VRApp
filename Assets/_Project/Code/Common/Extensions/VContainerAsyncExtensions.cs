using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UnrealTeam.Common.Extensions
{
    public static class VContainerAsyncExtensions
    {
        public static async UniTask<T> InstantiateAndInjectAsync<T>(
            this IObjectResolver objectResolver,
            T prefab)
            where T : Component
            => await objectResolver.WaitInstantiateOperationAndInject(Object.InstantiateAsync(prefab));

        public static async UniTask<T> InstantiateAndInjectAsync<T>(
            this IObjectResolver objectResolver,
            T prefab,
            Transform parent)
            where T : Component
            => await objectResolver.WaitInstantiateOperationAndInject(Object.InstantiateAsync(prefab, parent));

        public static async UniTask<T> InstantiateAndInjectAsync<T>(
            this IObjectResolver objectResolver,
            T prefab,
            Vector3 position,
            Quaternion rotation)
            where T : Component
            => await objectResolver.WaitInstantiateOperationAndInject(Object.InstantiateAsync(prefab, position, rotation));

        public static async UniTask<T> InstantiateAndInjectAsync<T>(this IObjectResolver objectResolver,
            T prefab,
            Transform parent,
            Vector3 position,
            Quaternion rotation)
            where T : Component
            => await objectResolver.WaitInstantiateOperationAndInject(Object.InstantiateAsync(prefab, parent, position, rotation));

        public static async UniTask<GameObject> InstantiateAndInjectAsync(
            this IObjectResolver objectResolver,
            GameObject prefab)
            => await objectResolver.WaitInstantiateOperationAndInject(Object.InstantiateAsync(prefab));
        
        public static async UniTask<GameObject> InstantiateAndInjectAsync(
            this IObjectResolver objectResolver,
            GameObject prefab,
            Transform parent) 
            => await objectResolver.WaitInstantiateOperationAndInject(Object.InstantiateAsync(prefab, parent));

        public static async UniTask<GameObject> InstantiateAndInjectAsync(this IObjectResolver objectResolver,
            GameObject prefab,
            Vector3 position,
            Quaternion rotation, 
            CancellationToken cancellationToken = default)
            => await objectResolver.WaitInstantiateOperationAndInject(Object.InstantiateAsync(prefab, position, rotation), cancellationToken);

        public static async UniTask<GameObject> InstantiateAndInjectAsync(this IObjectResolver objectResolver,
            GameObject prefab,
            Transform parent,
            Vector3 position,
            Quaternion rotation, 
            CancellationToken cancellationToken)
            => await objectResolver.WaitInstantiateOperationAndInject(Object.InstantiateAsync(prefab, parent, position, rotation), cancellationToken: cancellationToken);

        private static async UniTask<GameObject> WaitInstantiateOperationAndInject(
            this IObjectResolver objectResolver,
            AsyncInstantiateOperation<GameObject> instantiateOperation, 
            CancellationToken cancellationToken = default)
        {
            await instantiateOperation.ToUniTask(cancellationToken: cancellationToken);
            GameObject instantiatedObject = instantiateOperation.Result[0];
            objectResolver.InjectGameObject(instantiatedObject);
            return instantiatedObject;
        }        
        
        private static async UniTask<T> WaitInstantiateOperationAndInject<T>(
            this IObjectResolver objectResolver, 
            AsyncInstantiateOperation<T> instantiateOperation)
            where T : Component
        {
            await instantiateOperation.ToUniTask();
            T component = instantiateOperation.Result[0];
            objectResolver.InjectGameObject(component.gameObject);
            return component;
        }
    }
}
