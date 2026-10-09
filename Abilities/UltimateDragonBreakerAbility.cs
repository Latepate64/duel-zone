using Interfaces;
using Interfaces.Zones;

namespace Abilities;

/// <summary>
/// Crew breaker — Dragon (This creature breaks one more shield for each of your
/// other creatures in the battle zone that has Dragon in its race.)
/// </summary>
public sealed class UltimateDragonBreakerAbility : CrewBreakerAbility
{
    public UltimateDragonBreakerAbility()
    {
    }

    public UltimateDragonBreakerAbility(
        UltimateDragonBreakerAbility ability) : base(ability)
    {
    }

    public override IAbility Copy()
    {
        return new UltimateDragonBreakerAbility(this);
    }

    public override int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        if (!creature.Equals(Source)) return 1;
        return 1 + battleZone.GetNumberOfOtherDragonsControllerByPlayer(
            creature);
    }
}
