using Interfaces;

namespace GameEvents;

public sealed class UseCardEvent : GameEventV2
{
    public ICard Card { get; init; }
    public IEnumerable<ICard> PaymentCards { get; init; } = [];
    bool shouldEnd;

    public UseCardEvent(IPlayerV2 player, bool passable = true) : base(player, passable)
    {
    }

    UseCardEvent(UseCardEvent gameEvent) : base(gameEvent)
    {
        Card = gameEvent.Card.Copy();
        PaymentCards = gameEvent.PaymentCards.Select(x => x.Copy());
        shouldEnd = gameEvent.shouldEnd;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is UseCardEvent e
            && Card == e.Card
            && PaymentCards.SequenceEqual(e.PaymentCards)
            && shouldEnd == e.shouldEnd;
    }

    public override void Validate(IGameEventV2 gameEvent)
    {
        var use = IllegalActionException.ThrowIfNotOfType<UseCardEvent>(gameEvent);
        IllegalActionException.ThrowIf(use, !Player.Hand.Cards.Contains(use.Card),
            IllegalActionType.HandDoesNotContainCard);
        IllegalActionException.ThrowIf(use, use.PaymentCards.Any(x => x.Tapped),
            IllegalActionType.UseCardTappedManaForPayment);
        IllegalActionException.ThrowIf(use, use.PaymentCards.Count() != use.Card.ManaCost,
            IllegalActionType.UseCardPaymentForManaCost);
        IllegalActionException.ThrowIf(use, !HasCivilizations(use.PaymentCards, use.Card.Civilizations),
            IllegalActionType.UseCardPaymentForCivilizations);
    }

    static bool HasCivilizations(IEnumerable<ICard> manas, IEnumerable<Civilization> civs)
    {
        if (!civs.Any())
        {
            return true;
        }
        if (!manas.Any())
        {
            return false;
        }
        return manas.First().Civilizations.Any(x => HasCivilizations(manas.Skip(1), civs.Where(c => c != x)));
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        if (shouldEnd)
        {
            return [];
        }
        shouldEnd = true;
        foreach (var card in PaymentCards)
        {
            card.Tapped = true;
        }
        if (Card is ICreature creature)
        {
            // TODO: Consider evolution creature (supertype)
            // TODO: Create a separate event for putting
            return [new PutIntoBattleZoneEvent(Player, false, creature)];
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
}