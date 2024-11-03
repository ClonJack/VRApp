using UnityEngine;

namespace Common.Modules.Input
{
    public interface IValue2DInputModel : IPressed, IReleased, IHold, IName, IEnable, IDisable
    {
        public Vector2 GetValue2D();
    }
}