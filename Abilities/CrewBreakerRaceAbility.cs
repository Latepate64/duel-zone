using Interfaces;
using Interfaces.Zones;

namespace Abilities;

/// <summary>
/// Crew breaker — Race (This creature breaks one more shield for each of your
/// other Race creatures in the battle zone.)
/// </summary>
public sealed class CrewBreakerRaceAbility : CrewBreakerAbility
{
    public Race Race { get; }

    public CrewBreakerRaceAbility(CrewBreakerRaceAbility effect) : base(effect)
    {
        Race = effect.Race;
    }

    public CrewBreakerRaceAbility(Race race) : base()
    {
        Race = race;
    }

    public override int GetAmount(ICreature creature, IBattleZone battleZone)
    {
        if (!creature.Equals(Source)) return 1;
        return 1 + battleZone.GetNumberOfOtherRaceCreaturesControllerByPlayer(
            creature, Race);
    }

    public override IAbility Copy()
    {
        return new CrewBreakerRaceAbility(this);
    }
}
