using System.Collections.Generic;

namespace DuelMastersModels.Cards
{
    internal class DeckCreature : DeckCard, ICreature
    {
        public int Power { get; }
        public ICollection<Race> Races { get; }

        internal DeckCreature(ICard card) : base(card)
        {
        }
    }
}
