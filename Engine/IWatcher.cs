using Engine.GameEvents;

namespace Engine
{
    public interface IWatcher
    {
        void Watch(IGameEvent gameEvent);
    }
}
