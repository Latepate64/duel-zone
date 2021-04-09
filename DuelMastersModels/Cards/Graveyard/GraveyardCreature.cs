using System.Collections.Generic;

namespace DuelMastersModels.Cards
{
    internal class GraveyardCreature : GraveyardCard, ICreature
    {
        public int Power { get; }
        public ICollection<Race> Races { get; }

        internal GraveyardCreature(ICard card) : base(card)
        {
        }
    }
}
