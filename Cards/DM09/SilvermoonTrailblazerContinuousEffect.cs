using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM09;

public class SilvermoonTrailblazerContinuousEffect : UntilEndOfTurnEffect, IUnblockableEffect
{
    private readonly Race _race;

    public SilvermoonTrailblazerContinuousEffect(SilvermoonTrailblazerContinuousEffect effect) : base(effect)
    {
        _race = effect._race;
    }

    public SilvermoonTrailblazerContinuousEffect(Race race) : base()
    {
        _race = race;
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
    {
        return attacker.HasRace(_race) && blocker.Power <= 3000;
    }

    public override IContinuousEffect Copy()
    {
        return new SilvermoonTrailblazerContinuousEffect(this);
    }

    public override string ToString()
    {
        return $"{_race}s can't be blocked by creatures that have power 3000 or less this turn.";
    }
}
