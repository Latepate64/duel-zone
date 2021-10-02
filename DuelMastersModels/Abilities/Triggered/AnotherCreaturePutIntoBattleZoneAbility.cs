using DuelMastersModels.Cards;
using DuelMastersModels.Zones;
using System;

namespace DuelMastersModels.Abilities.Triggered
{
    public abstract class AnotherCreaturePutIntoBattleZoneAbility : CardChangesZoneAbility
    {
        protected AnotherCreaturePutIntoBattleZoneAbility()
        {
        }

        protected AnotherCreaturePutIntoBattleZoneAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(Duel duel, Guid source, Card card, ZoneType destinationZone)
        {
            return card.CardType == CardType.Creature && source != card.Id && destinationZone == ZoneType.BattleZone;
        }
    }
}
