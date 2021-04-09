using System.Collections.Generic;

namespace DuelMastersModels.Cards
{
    internal class ShieldZoneCreature : ShieldZoneCard, ICreature
    {
        public int Power { get; }
        public ICollection<Race> Races { get; }

        internal ShieldZoneCreature(ICard card) : base(card)
        {
        }
    }
}
