namespace Interfaces;

public interface IResolvableAbility : IAbility
{
    void Resolve(IGame game);
}
