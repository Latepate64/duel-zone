using Interfaces;
using Interfaces.Zones;

namespace Abilities.Static;

/// <summary>
/// Crew breaker — Dragon (This creature breaks one more shield for each of your
/// other creatures in the battle zone that has Dragon in its race.)
/// </summary>
public sealed class CrewBreakerDragonAbility : CrewBreakerAbility
{
    public CrewBreakerDragonAbility()
    {
    }

    public CrewBreakerDragonAbility(
        CrewBreakerDragonAbility ability) : base(ability)
    {
    }

    public override IAbility Copy()
    {
        return new CrewBreakerDragonAbility(this);
    }

    public override int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        if (!creature.Equals(Source)) return 1;
        return 1 + battleZone.GetNumberOfOtherDragonsControllerByPlayer(
            creature);
    }
}
