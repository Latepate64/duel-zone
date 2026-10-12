using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects.Unblockable;

/// <summary>
/// This creature can't be blocked while you have at least x other creatures in
/// the battle zone.
/// </summary>
public sealed class ThisCreatureCannotBeBlockedWhileYouControlOtherCreaturesEffect
    : ContinuousEffect, IUnblockableEffect
{
    private readonly ICardFilter filter;
    private readonly int minimum;

    public ThisCreatureCannotBeBlockedWhileYouControlOtherCreaturesEffect(
        ICardFilter filter, int minimum) : base()
    {
        this.filter = filter;
        this.minimum = minimum;
    }

    public ThisCreatureCannotBeBlockedWhileYouControlOtherCreaturesEffect(
        ThisCreatureCannotBeBlockedWhileYouControlOtherCreaturesEffect effect)
            : base(effect)
    {
        filter = effect.filter.Copy();
        minimum = effect.minimum;
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        if (!IsSourceOfAbility(attacker)) return false;
        if (battleZone.GetNumberOfOtherCreaturesControllerByPlayer(
            attacker, filter) < minimum) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotBeBlockedWhileYouControlOtherCreaturesEffect(
            this);
    }
}
