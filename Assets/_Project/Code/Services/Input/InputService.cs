using System;
using UnrealTeam.Common.Modules.InputControl;
using UnrealTeam.VR.Input;

namespace UnrealTeam.VR.Services.Input
{
    public class InputService : IInputService, IDisposable
    {
        public IValueInputModel Keyboard { get; private set; }
        public IValueInputModel NavigateY { get; private set; }
        public IValueInputModel NavigateX { get; private set; }
        public IKeyInputModel NavigatePress { get; private set; }
        
        
        private PlayerInputMap _playerInput;

        
        public InputService()
        {
            _playerInput = new PlayerInputMap(); 
            _playerInput.Enable();
            
            Keyboard = new InputValueModel(_playerInput.Player.Keyboard);
            NavigateY = new InputValueModel(_playerInput.Player.NavigateY);
            NavigateX = new InputValueModel(_playerInput.Player.NavigateX);
            NavigatePress = new InputKeyModel(_playerInput.Player.NavigateSelect);
        }

        public void Dispose()
        {
            _playerInput?.Dispose();
        }
    }
}