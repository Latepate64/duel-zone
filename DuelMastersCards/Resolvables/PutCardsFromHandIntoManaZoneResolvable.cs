﻿using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class PutCardsFromHandIntoManaZoneResolvable : Resolvable
    {
        public int Amount { get; set; }

        public PutCardsFromHandIntoManaZoneResolvable(int amount)
        {
            Amount = amount;
        }

        public PutCardsFromHandIntoManaZoneResolvable(PutCardsFromHandIntoManaZoneResolvable resolvable) : base(resolvable)
        {
            Amount = resolvable.Amount;
        }

        public override Resolvable Copy()
        {
            return new PutCardsFromHandIntoManaZoneResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                var cards = duel.GetPlayer(Controller).Hand.Cards;
                if (cards.Any())
                {
                    return new GuidSelection(Controller, cards, 0, Amount);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                foreach (var card in (decision as GuidDecision).Decision.Select(x => duel.GetCard(x)))
                {
                    var player = duel.GetPlayer(card.Owner);
                    player.Move(duel, card, player.Hand, player.ManaZone);
                }
                return null;
            }
        }
    }
}