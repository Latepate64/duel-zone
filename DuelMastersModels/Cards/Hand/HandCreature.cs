using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    internal class HandCreature : HandCard, IHandCreature
    {
        public int Power { get; }
        public ReadOnlyCollection<string> Races { get; }

        internal HandCreature(ICard card) : base(card)
        {
        }
    }
}
