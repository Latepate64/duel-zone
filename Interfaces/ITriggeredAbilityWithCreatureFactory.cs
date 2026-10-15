namespace Interfaces;

public interface ITriggeredAbilityWithCreatureFactory
{
    ITriggeredAbility Create(ICreature creature);
}