using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

public sealed class RaceCreaturesCannotBeBlockedEffect : ContinuousEffect, IUnblockableEffect
{
    private readonly Race race;
    private readonly ICardFilter blockerFilter;

    public RaceCreaturesCannotBeBlockedEffect(Race race, ICardFilter blockerFilter) : base()
    {
        this.race = race;
        this.blockerFilter = blockerFilter;
    }

    private RaceCreaturesCannotBeBlockedEffect(
        RaceCreaturesCannotBeBlockedEffect effect) : base(effect)
    {
        race = effect.race;
        blockerFilter = effect.blockerFilter.Copy();
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!attacker.HasRace(race)) return false;
        if (!blockerFilter.Match(blocker)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new RaceCreaturesCannotBeBlockedEffect(this);
    }
}
