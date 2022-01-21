using DuelMastersModels.ContinuousEffects;
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

        public void UntapCards(Guid owner)
        {
            foreach (Card card in Cards.Where(x => x.Owner == owner && x.Tapped))
            {
                card.Tapped = false;
            }
        }

        public override void Add(Card card, Game game)
        {
            Cards.Add(card);
            card.RevealedTo = game.Players.Select(x => x.Id).ToList();
        }

        public override void Remove(Card card, Game game)
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

        public IEnumerable<Card> GetChoosableCreatures(Game game, Guid owner)
        {
            return Creatures.Where(x => x.Owner == owner && !game.GetContinuousEffects<UnchoosableEffect>(x).Any());
        }

        public override string ToString()
        {
            return "battle zone";
        }
    }
}