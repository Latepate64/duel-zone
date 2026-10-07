using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

/// <summary>
/// Creatures of that race can't be blocked by creatures that have power 3000 or
/// less this turn.
/// </summary>
public sealed class SilvermoonTrailblazerContinuousEffect :
    UntilEndOfTurnEffect, IUnblockableEffect
{
    private readonly Race _race;

    public SilvermoonTrailblazerContinuousEffect(
        SilvermoonTrailblazerContinuousEffect effect) : base(effect)
    {
        _race = effect._race;
    }

    public SilvermoonTrailblazerContinuousEffect(Race race) : base()
    {
        _race = race;
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!attacker.HasRace(_race)) return false;
        if (blocker.Power > 3000) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new SilvermoonTrailblazerContinuousEffect(this);
    }
}
