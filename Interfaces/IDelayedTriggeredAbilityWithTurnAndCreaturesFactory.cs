namespace Interfaces;

public interface IDelayedTriggeredAbilityWithTurnAndCreaturesFactory
{
    IDelayedTriggeredAbility Create(
        IAbility ability, Guid turn, params ICreature[] creatures);
}
