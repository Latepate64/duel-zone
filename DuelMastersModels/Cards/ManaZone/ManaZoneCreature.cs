using System.Collections.Generic;

namespace DuelMastersModels.Cards
{
    internal class ManaZoneCreature : ManaZoneCard, IManaZoneCreature
    {
        public int Power { get; }
        public ICollection<Race> Races { get; }

        internal ManaZoneCreature(ICard card) : base(card)
        {
        }
    }
}
