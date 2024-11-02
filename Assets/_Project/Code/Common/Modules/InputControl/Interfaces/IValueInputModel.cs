namespace Common.Modules.Input
{
    public interface IValueInputModel : IPressed, IReleased, IHold, IName, IEnable, IDisable
    {
        float Value();
    }
}