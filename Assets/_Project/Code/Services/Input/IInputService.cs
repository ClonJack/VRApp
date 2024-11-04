using UnrealTeam.Common.Modules.InputControl;

namespace UnrealTeam.VR.Services.Input
{
    public interface IInputService
    {
        public IValueInputModel Keyboard { get; }
        public IValueInputModel NavigateY { get; }
        public IValueInputModel NavigateX { get; }
        public IKeyInputModel NavigatePress { get; }
    }
}