namespace Interfaces;

public interface IExpirable
{
    bool ShouldExpire(IGameEvent gameEvent, IGame game);
}