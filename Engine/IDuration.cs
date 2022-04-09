using Common.GameEvents;

namespace Engine
{
    public interface IDuration
    {
        bool ShouldExpire(IGameEvent gameEvent);
    }
}