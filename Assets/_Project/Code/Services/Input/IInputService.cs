namespace Common.Modules.Input
{
    public interface IInputService
    {
        public IValueInputModel Keyboard { get; }
        public IValueInputModel NavigateY { get; }
        public IValueInputModel NavigateX { get; }
        public IKeyInputModel NavigateSelect { get; }
    }
}