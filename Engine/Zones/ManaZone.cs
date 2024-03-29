﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
    /// </summary>
    public class ManaZone : Zone, IManaZone
    {
        public ManaZone() : base(ZoneType.ManaZone) { }

        public ManaZone(IManaZone zone) : base(zone)
        {
        }

        public IEnumerable<ICard> TappedCards => new ReadOnlyCollection<ICard>(Cards.Where(card => card.Tapped).ToList());
        public IEnumerable<ICard> UntappedCards => new ReadOnlyCollection<ICard>(Cards.Where(card => !card.Tapped).ToList());

        public override void Add(ICard card, IGame game)
        {
            card.KnownTo = game.Players.Select(x => x.Id).ToList();
            if (card.IsMultiColored)
            {
                card.Tapped = true;
            }
            Cards.Add(card);
        }

        public override List<ICard> Remove(ICard card, IGame game)
        {
            if (Cards.Remove(card))
            {
                return new List<ICard> { card };
            }
            else
            {
                return new List<ICard>();
            }
        }

        private static IEnumerable<IEnumerable<Civilization>> GetCivilizationSubsequences(IEnumerable<ICard> cards, IEnumerable<Civilization> civs)
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

        public override string ToString()
        {
            return "mana zone";
        }

        public IManaZone Copy()
        {
            return new ManaZone(this);
        }

        public IEnumerable<ICard> GetNonEvolutionCreaturesThatCostSameOrLessThan(int maximum)
        {
            return Creatures.Where(c => !c.IsEvolutionCreature && c.ManaCost <= maximum);
        }
    }
}