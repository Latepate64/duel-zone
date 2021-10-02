using DuelMastersModels.Cards;
using DuelMastersModels.Zones;
using System;

namespace DuelMastersModels.Abilities.Triggered
{
    public abstract class CardChangesZoneAbility : TriggeredAbility
    {
        protected CardChangesZoneAbility()
        {
        }

        protected CardChangesZoneAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public abstract bool CanTrigger(Duel duel, Guid source, Card card, ZoneType destinationZone);
    }
}
