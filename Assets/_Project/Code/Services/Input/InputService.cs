using System;
using Common.Modules.Input.Template;
using UnrealTeam.VR.Input;


namespace Common.Modules.Input
{
    public class InputService : IInputService, IDisposable
    {
        private PlayerInputMap _playerInput;
        
        public IValueInputModel Keyboard { get; private set; }

        
        public InputService()
        {
            _playerInput = new PlayerInputMap(); 
            _playerInput.Enable();
            
            Keyboard = new InputValueModel(_playerInput.Player.Keyboard);
        }

        public void Dispose()
        {
            _playerInput?.Dispose();
        }

      
    }
}