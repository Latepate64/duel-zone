using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects;

public class ChosenCreaturesCannotBeBlockedThisTurnEffect : UntilEndOfTurnEffect, IUnblockableEffect
{
    private readonly Card[] _cards;

    public ChosenCreaturesCannotBeBlockedThisTurnEffect(params Card[] cards) : base()
    {
        _cards = cards;
    }

    public ChosenCreaturesCannotBeBlockedThisTurnEffect(ChosenCreaturesCannotBeBlockedThisTurnEffect effect) : base(effect)
    {
        _cards = effect._cards;
    }

    public bool CannotBeBlocked(Creature attacker, Creature blocker, IAttackable targetOfAttack, IGame game)
    {
        return _cards.Any(x => x.Id == attacker.Id);
;        }

    public override IContinuousEffect Copy()
    {
        return new ChosenCreaturesCannotBeBlockedThisTurnEffect(this);
    }

    public override string ToString()
    {
        return "This creature can't be blocked this turn.";
    }
}