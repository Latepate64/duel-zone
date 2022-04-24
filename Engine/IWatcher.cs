using Engine.GameEvents;

namespace Engine
{
    public interface IWatcher
    {
        void Watch(IGame game, IGameEvent gameEvent);
    }
}
