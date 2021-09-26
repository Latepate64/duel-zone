﻿using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
    /// </summary>
    public class ManaZone : Zone, ICopyable<ManaZone>
    {
        public ManaZone(IEnumerable<Card> cards) : base(cards) { }

        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        public IEnumerable<Card> TappedCards => new ReadOnlyCollection<Card>(Cards.Where(card => card.Tapped).ToList());
        public IEnumerable<Card> UntappedCards => new ReadOnlyCollection<Card>(Cards.Where(card => !card.Tapped).ToList());

        public void UntapCards()
        {
            foreach (Card card in TappedCards)
            {
                card.Tapped = false;
            }
        }

        public override void Add(Card card, Duel duel)
        {
            card.RevealedTo = duel.Players.Select(x => x.Id);
            if (card.Civilizations.Count() > 1)
            {
                card.Tapped = true;
            }
            _cards.Add(card);
        }

        public override void Remove(Card card)
        {
            if (!_cards.Remove(card))
            {
                throw new System.NotSupportedException(card.ToString());
            }
        }

        private static IEnumerable<IEnumerable<Civilization>> GetCivilizationSubsequences(IEnumerable<Card> cards, IEnumerable<Civilization> civs)
        {
            if (cards.Any())
            {
                return new List<IEnumerable<Civilization>> { civs.Distinct() };
            }
            else
            {
                return cards.First().Civilizations.Select(x => civs.Append(x)).SelectMany(x => GetCivilizationSubsequences(cards.Skip(1), x)).Distinct();
            }
        }

        public ManaZone Copy()
        {
            return new ManaZone(Cards.Select(x => x.Copy()));
        }
    }
}