using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    internal class ManaZoneCreature : ManaZoneCard, IManaZoneCreature
    {
        public int Power { get; }
        public ReadOnlyCollection<string> Races { get; }

        internal ManaZoneCreature(ICard card) : base(card)
        {
        }
    }
}
