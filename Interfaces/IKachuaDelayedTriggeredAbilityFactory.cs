namespace Interfaces;

public interface IKachuaDelayedTriggeredAbilityFactory
{
    IDelayedTriggeredAbility Create(
        IAbility ability, Guid turn, ICreature creature);
}
