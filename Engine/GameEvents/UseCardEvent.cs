using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Engine.GameEvents;

public sealed class UseCardEvent(IPlayerV2 player, bool passable = true) : GameEventV2(player, passable)
{
    public ICard Card { get; init; }
    public IEnumerable<ICard> PaymentCards { get; init; } = [];
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

    internal override IEnumerable<GameEventV2> Happen(GameState state)
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
}