using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    internal class GraveyardCreature : GraveyardCard, ICreature
    {
        public int Power { get; }
        public ReadOnlyCollection<string> Races { get; }

        internal GraveyardCreature(ICard card) : base(card)
        {
        }
    }
}
