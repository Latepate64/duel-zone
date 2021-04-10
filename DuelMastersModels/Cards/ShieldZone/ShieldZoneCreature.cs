using DuelMastersModels.Abilities.TriggerAbilities;
using System.Collections.Generic;

namespace DuelMastersModels.Cards
{
    internal class ShieldZoneCreature : ShieldZoneCard, ICreature
    {
        public int Power { get; }
        public ICollection<Race> Races { get; }
        public bool SummoningSickness { get; set; }
        public ICollection<ITriggerAbility> TriggerAbilities { get; }

        internal ShieldZoneCreature(ICard card) : base(card)
        {
        }
    }
}
