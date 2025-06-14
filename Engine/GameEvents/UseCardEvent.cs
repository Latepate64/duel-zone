using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.GameEvents;

public class UseCardEvent(PlayerV2 player, bool passable = true) : GameEventV2(player, passable)
{
    public Card Card { get; set; }
    public List<Card> PaymentCards { get; set; } = [];
    bool shouldEnd;

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is UseCardEvent e
            && Card == e.Card
            && PaymentCards.SequenceEqual(e.PaymentCards)
            && shouldEnd == e.shouldEnd;
    }

    internal override void Validate(GameEventV2 gameEvent)
    {
        var use = IllegalActionException.ThrowIfNotOfType<UseCardEvent>(gameEvent);
        IllegalActionException.ThrowIf(gameEvent, !Player.Hand.Cards.Contains(use.Card),
            IllegalActionType.HandDoesNotContainCard);
        IllegalActionException.ThrowIf(gameEvent, use.PaymentCards.Any(x => x.Tapped),
            IllegalActionType.UseCardTappedManaForPayment);
        IllegalActionException.ThrowIf(gameEvent, use.PaymentCards.Count != use.Card.ManaCost,
            IllegalActionType.UseCardPaymentForManaCost);
        IllegalActionException.ThrowIf(gameEvent, !HasCivilizations(use.PaymentCards, use.Card.Civilizations),
            IllegalActionType.UseCardPaymentForCivilizations);
    }

    static bool HasCivilizations(IEnumerable<Card> manas, IEnumerable<Civilization> civs)
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

    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        if (shouldEnd)
        {
            return [];
        }
        shouldEnd = true;
        foreach (var card in PaymentCards)
        {
            card.Tap();
        }
        if (Card.IsCreature)
        {
            // TODO: Consider evolution creature (supertype)
            // TODO: Create a separate event for putting
            return [new PutIntoBattleZoneEvent(Player, false, Card)];
        }
        if (Card.IsSpell)
        {
            Player.Hand.Remove(Card, null); // TODO: May not be in hand always
            // TODO: Resolve spell
            return [new PutIntoGraveyardEvent(Player, Card)];
        }
        throw new InvalidOperationException();
    }
}