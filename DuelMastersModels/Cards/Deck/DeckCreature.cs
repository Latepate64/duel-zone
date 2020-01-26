using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    internal class DeckCreature : DeckCard, ICreature
    {
        public int Power { get; }
        public ReadOnlyCollection<string> Races { get; }

        internal DeckCreature(ICard card) : base(card)
        {
        }
    }
}
