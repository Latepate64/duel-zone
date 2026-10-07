using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects;

/// <summary>
/// This creature can't be blocked by any creature that has power x or less.
/// </summary>
public class ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect :
    ContinuousEffect, IUnblockableEffect, IPowerable
{
    public ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(
        ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect effect) :
            base(effect)
    {
        Power = effect.Power;
    }

    public ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(
        int power) : base()
    {
        Power = power;
    }

    public int Power { get; }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        if (blocker.Power > Power) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new
            ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(this);
    }
}
