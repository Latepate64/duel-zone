using DuelMastersModels.Abilities.TriggeredAbilities;
using System.Collections.Generic;

namespace DuelMastersModels.Cards
{
    internal class ManaZoneCreature : ManaZoneCard, IManaZoneCreature
    {
        public int Power { get; }
        public ICollection<Race> Races { get; }
        public bool SummoningSickness { get; set; }
        public ICollection<TriggeredAbility> TriggerAbilities { get; }

        internal ManaZoneCreature(ICard card) : base(card)
        {
        }
    }
}
