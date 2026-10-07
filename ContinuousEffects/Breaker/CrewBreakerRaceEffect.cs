using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Breaker;

/// <summary>
/// Crew breaker — Race (This creature breaks one more shield for each of your
/// other Race creatures in the battle zone.)
/// </summary>
public sealed class CrewBreakerRaceEffect : CrewBreakerEffect, IRaceable
{
    public Race Race { get; }

    public CrewBreakerRaceEffect(CrewBreakerRaceEffect effect) : base(effect)
    {
        Race = effect.Race;
    }

    public CrewBreakerRaceEffect(Race race) : base()
    {
        Race = race;
    }

    public override string ToString()
    {
        return $"Crew breaker - {Race}";
    }

    public override int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(creature)) return 1;
        return 1 + battleZone.GetNumberOfOtherRaceCreaturesControllerByPlayer(
            creature, Race);
    }

    public override IContinuousEffect Copy()
    {
        return new CrewBreakerRaceEffect(this);
    }
}
