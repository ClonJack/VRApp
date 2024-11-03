using System;
using _Project.Code.Services;
using BNG;
using Common.Modules.Input;
using TriInspector;
using UnityEngine;
using VContainer;

namespace _Project.Code.GamePlay.PlayerController
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [field: Title("Ref"), SerializeField]
        public ScreenFader ScreenFader { get; private set; }

        [SerializeField]
        private Transform _pointKeyboard;
        
        
        private IInputService _inputService;
        private ObjectsProvider _objectsProvider;

        
        [Inject]
        public void Construct(IInputService inputService, ObjectsProvider objectsProvider)
        {
            _inputService = inputService;
            _objectsProvider = objectsProvider;
        }

        public void Update()
        {
            UpdateKeyboardState();
        }

        private void UpdateKeyboardState()
        {
            if (_inputService.Keyboard.IsPressed())
                _objectsProvider.KeyboardBehaviour.UpdatePosition(_pointKeyboard);
        }
    }
}