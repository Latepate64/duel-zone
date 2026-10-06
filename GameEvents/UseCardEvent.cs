using Interfaces;

namespace GameEvents;

public sealed class UseCardEvent : PassableTurnBasedAction
{
    public ICard? Card { get; init; }
    public IEnumerable<ICard> PaymentCards { get; init; } = [];
    bool shouldEnd;

    public UseCardEvent(IPlayerV2 player) : base(player)
    {
    }

    UseCardEvent(UseCardEvent gameEvent) : base(gameEvent)
    {
        Card = gameEvent.Card?.Copy();
        PaymentCards = gameEvent.PaymentCards.Select(x => x.Copy());
        shouldEnd = gameEvent.shouldEnd;
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not UseCardEvent e) return false;
        if (Card != e.Card) return false;
        if (!PaymentCards.SequenceEqual(e.PaymentCards)) return false;
        if (shouldEnd != e.shouldEnd) return false;
        return true;
    }

    public override void Validate(IPassableGameEvent gameEvent)
    {
        var use = IllegalActionException.ThrowIfNotOfType<UseCardEvent>(
            gameEvent);
        if (use.Card == null) return;
        IllegalActionException.ThrowIf(
            use, !Player.Hand.Contains(use.Card),
            IllegalActionType.HandDoesNotContainCard);
        IllegalActionException.ThrowIf(use, use.PaymentCards.Any(x => x.Tapped),
            IllegalActionType.UseCardTappedManaForPayment);
        IllegalActionException.ThrowIf(
            use, use.PaymentCards.Count() != use.Card.ManaCost,
            IllegalActionType.UseCardPaymentForManaCost);
        IllegalActionException.ThrowIf(
            use, !HasCivilizations(use.PaymentCards, use.Card.Civilizations),
            IllegalActionType.UseCardPaymentForCivilizations);
    }

    static bool HasCivilizations(
        IEnumerable<ICard> manas, IEnumerable<Civilization> civs)
    {
        if (!civs.Any()) return true;
        if (!manas.Any()) return false;
        return manas.First().Civilizations.Any(
            x => HasCivilizations(manas.Skip(1), civs.Where(c => c != x)));
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        if (shouldEnd) return [];
        shouldEnd = true;
        if (Card == null) return [];
        foreach (var card in PaymentCards)
        {
            card.Tapped = true;
        }
        if (Card is ICreature creature)
        {
            // TODO: Consider evolution creature (supertype)
            // TODO: Create a separate event for putting
            return [new PutIntoBattleZoneEvent(Player, creature)];
        }
        if (Card is ISpell spell)
        {
            Player.Hand.Remove(spell); // TODO: May not be in hand always
            // TODO: Resolve spell
            return [new PutIntoGraveyardEvent(Player, spell)];
        }
        throw new InvalidOperationException();
    }

    public override IGameEventV2 Copy()
    {
        return new UseCardEvent(this);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            base.GetHashCode(), Card, PaymentCards, shouldEnd);
    }
}