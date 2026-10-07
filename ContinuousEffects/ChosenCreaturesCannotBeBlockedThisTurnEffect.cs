using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace ContinuousEffects;

/// <summary>
/// This creature can't be blocked this turn.
/// </summary>
public sealed class ChosenCreaturesCannotBeBlockedThisTurnEffect :
    UntilEndOfTurnEffect, IUnblockableEffect
{
    private readonly ICard[] _cards;

    public ChosenCreaturesCannotBeBlockedThisTurnEffect(
        params ICard[] cards) : base()
    {
        _cards = cards;
    }

    public ChosenCreaturesCannotBeBlockedThisTurnEffect(
        ChosenCreaturesCannotBeBlockedThisTurnEffect effect) : base(effect)
    {
        _cards = [.. effect._cards];
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker,
        IAttackable targetOfAttack, IBattleZone battleZone)
    {
        return _cards.Any(x => x.Id == attacker.Id);
    }

    public override IContinuousEffect Copy()
    {
        return new ChosenCreaturesCannotBeBlockedThisTurnEffect(this);
    }
}