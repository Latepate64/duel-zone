﻿using DuelMastersModels.ContinuousEffects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    public class BattleZone : Zone
    {
        public BattleZone(IEnumerable<Card> cards) : base(cards)
        {
        }

        public BattleZone(BattleZone zone) : base(zone.Cards.Select(x => x.Copy()))
        {
        }

        public void UntapCards()
        {
            foreach (Card card in Cards.Where(x => x.Tapped))
            {
                card.Tapped = false;
            }
        }

        public override void Add(Card card, Duel duel)
        {
            Cards.Add(card);
            card.RevealedTo = duel.Players.Select(x => x.Id).ToList();
        }

        public override void Remove(Card card)
        {
            if (!Cards.Remove(card))
            {
                throw new NotSupportedException(card.ToString());
            }
        }

        public override Zone Copy()
        {
            return new BattleZone(this);
        }

        public IEnumerable<Card> GetChoosableCreatures(Duel duel)
        {
            return Creatures.Where(x => !duel.GetContinuousEffects<UnchoosableEffect>(x).Any());
        }

        public override string ToString()
        {
            return "battle zone";
        }
    }
}