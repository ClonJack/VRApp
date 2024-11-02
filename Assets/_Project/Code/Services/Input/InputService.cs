using System;
using UnrealTeam.VR.Input;


namespace Common.Modules.Input
{
    public class InputService : IInputService, IDisposable
    {
        private PlayerInputMap _playerInput;


        public InputService()
        {
            _playerInput = new PlayerInputMap();
            _playerInput.Enable();
        }

        public void Dispose()
        {
            _playerInput?.Dispose();
        }
    }
}