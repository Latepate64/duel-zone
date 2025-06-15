using System.Collections.Generic;
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

        public IEnumerable<Card> TappedCards => Cards.Where(card => card.Tapped);
        public IEnumerable<Card> UntappedCards => Cards.Where(card => !card.Tapped);

        public bool AreAllCivilizationCards(Civilization civ) => Cards.All(x => x.HasCivilization(civ));

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