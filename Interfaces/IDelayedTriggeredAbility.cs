namespace Interfaces;

public interface IDelayedTriggeredAbility
{
    IDelayedTriggeredAbility Copy();
    void Dispose();
    IDelayedTriggeredAbility CreateNew(
        IAbility ability, Guid turn, IOneShotEffect effect);
}