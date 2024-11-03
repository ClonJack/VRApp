using System;
using Common.Modules.Input.Template;
using UnrealTeam.VR.Input;


namespace Common.Modules.Input
{
    public class InputService : IInputService, IDisposable
    {
        private PlayerInputMap _playerInput;
        
        public IValueInputModel Keyboard { get; private set; }
        public IValueInputModel NavigateY { get; private set; }
        public IValueInputModel NavigateX { get; private set; }
        
        public IKeyInputModel NavigateSelect { get; private set; }

        public InputService()
        {
            _playerInput = new PlayerInputMap(); 
            _playerInput.Enable();
            
            Keyboard = new InputValueModel(_playerInput.Player.Keyboard);
            NavigateY = new InputValueModel(_playerInput.Player.NavigateY);
            NavigateX = new InputValueModel(_playerInput.Player.NavigateX);
            NavigateSelect = new InputKeyModel(_playerInput.Player.NavigateSelect);
        }

        public void Dispose()
        {
            _playerInput?.Dispose();
        }
        
    }
}