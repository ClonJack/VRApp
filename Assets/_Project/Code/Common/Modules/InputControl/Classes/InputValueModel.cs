using UnityEngine.InputSystem;

namespace Common.Modules.Input.Template
{
    public class InputValueModel : IValueInputModel
    {
        private readonly InputAction _inputAction;

        public InputValueModel(InputAction inputAction)
        {
            _inputAction = inputAction;
        }
        public bool IsPressed() => _inputAction.WasPressedThisFrame();
        public bool IsReleased() => _inputAction.WasReleasedThisFrame();
        public bool IsHold() => _inputAction.IsPressed();
        public void Enable() => _inputAction.Enable();
        public void Disable() => _inputAction.Disable();
        public float Value() => _inputAction.ReadValue<float>();
        public string NameKey => _inputAction.GetBindingDisplayString();
    }
}