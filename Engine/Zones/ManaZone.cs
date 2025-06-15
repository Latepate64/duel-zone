using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
    /// </summary>
    public class ManaZone : Zone
    {
        public ManaZone(params Card[] cards) : base(ZoneType.ManaZone, cards) { }

        public ManaZone(ManaZone zone) : base(zone)
        {
        }

        public IEnumerable<Card> TappedCards => new ReadOnlyCollection<Card>([.. Cards.Where(card => card.Tapped)]);
        public IEnumerable<Card> UntappedCards => new ReadOnlyCollection<Card>([.. Cards.Where(card => !card.Tapped)]);

        internal override void Add(Card card)
        {
            if (card.IsMultiColored)
            {
                // card.Tapped = true;
            }
            Cards.Add(card);
        }

        internal override List<Card> Remove(Card card, IGame game)
        {
            if (Cards.Remove(card))
            {
                return [card];
            }
            else
            {
                return [];
            }
        }

        private static IEnumerable<IEnumerable<Civilization>> GetCivilizationSubsequences(IEnumerable<Card> cards, IEnumerable<Civilization> civs)
        {
            if (cards.Any())
            {
                return [civs.Distinct()];
            }
            else
            {
                return cards.First().Civilizations.Select(x => civs.Append(x)).SelectMany(x => GetCivilizationSubsequences(cards.Skip(1), x)).Distinct();
            }
        }

        public ManaZone Copy()
        {
            return new ManaZone(this);
        }

        public IEnumerable<Card> GetNonEvolutionCreaturesThatCostSameOrLessThan(int maximum)
        {
            return Creatures.Where(c => !c.IsEvolutionCreature && c.ManaCost <= maximum);
        }
    }
}