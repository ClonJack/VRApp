using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using TriInspector;
using UnityEngine;
using UnrealTeam.Common.Extensions;
using UnrealTeam.VR.Services;
using UnrealTeam.VR.Services.Input;
using VContainer;

namespace UnrealTeam.VR.GamePlay.Behaviours
{
    public class KeyboardBehaviour : MonoBehaviour
    {
        [Title("Ref"), SerializeField]
        private SerializedDictionary<int, List<GameObject>> _mapRows = new();
        
        [Title("Settings"), SerializeField]
        private Vector3 offset;
        
        
        private List<GameObject> _currentMap = new();
        private ObjectsProvider _objectsProvider;
        private IInputService _inputService;
        
        
        [Inject]
        public void Construct(IInputService inputService, ObjectsProvider objectsProvider)
        {
            _inputService = inputService;
            _objectsProvider = objectsProvider;
        }
        
        public void Start()
        {
            UpdateMap(0);
        }

        public void UpdateKeyboardPosition(Transform target)
        {
            var worldPosition = target.TransformPoint(offset);
            
            transform.position = worldPosition;
            transform.rotation = target.rotation;
        }
        
        public void UpdateNavigateKey()
        {
            var currentKey = _objectsProvider.VrUISystem.ReleasingObject == null
                ? _currentMap[0].transform
                : _objectsProvider.VrUISystem.ReleasingObject.transform;
            
            var navigation = Vector2Int.RoundToInt(new Vector2( _inputService.NavigateX.GetValue(),
                _inputService.NavigateY.GetValue()));
            
            var targetKey = currentKey;
            
            if (_inputService.NavigateY.IsPressed())
                targetKey = GetNewRow(targetKey, navigation.y);
            
            if (_inputService.NavigateX.IsPressed())
                targetKey = GetNewIndex(targetKey, navigation.x);
            
            _objectsProvider.VrUISystem.SetManuallyHover(targetKey.gameObject);
        }
        
        public void UpdateMap(int count) => 
            _currentMap = _mapRows[count];
        
        private Transform GetNewRow(Transform currentKey, int offset)
        {
            var currentRow = currentKey.parent.GetSiblingIndex();
            var newRow = Mathf.Clamp(currentRow - offset, 0, _currentMap.Count - 1);
            
            return _currentMap[newRow].transform.FindNearestChild(currentKey);
        }

        private Transform GetNewIndex(Transform currentKey, int offset)
        {
            var currentIndex = currentKey.GetSiblingIndex();
            var newIndex = Mathf.Clamp(currentIndex + offset, 0, currentKey.parent.childCount - 1);
            
            return currentKey.parent.GetChild(newIndex);
        }
    }
}