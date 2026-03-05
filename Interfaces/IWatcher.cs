namespace Interfaces;

public interface IWatcher
{
    void Watch(IGame game, IGameEvent gameEvent);
}
