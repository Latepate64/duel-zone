using Engine.GameEvents;

namespace Engine
{
    public interface IExpirable
    {
        bool ShouldExpire(IGameEvent gameEvent);
    }
}