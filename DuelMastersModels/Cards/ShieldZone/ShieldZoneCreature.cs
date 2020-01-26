using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    internal class ShieldZoneCreature : ShieldZoneCard, ICreature
    {
        public int Power { get; }
        public ReadOnlyCollection<string> Races { get; }

        internal ShieldZoneCreature(ICard card) : base(card)
        {
        }
    }
}
