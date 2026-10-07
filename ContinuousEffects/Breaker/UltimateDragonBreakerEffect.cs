using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Breaker;

/// <summary>
/// Crew breaker — Dragon (This creature breaks one more shield for each of your
/// other creatures in the battle zone that has Dragon in its race.)
/// </summary>
public sealed class UltimateDragonBreakerEffect : CrewBreakerEffect
{
    public override IContinuousEffect Copy()
    {
        return new UltimateDragonBreakerEffect();
    }

    public override int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(creature)) return 1;
        return 1 + battleZone.GetNumberOfOtherDragonsControllerByPlayer(
            creature);
    }
}
