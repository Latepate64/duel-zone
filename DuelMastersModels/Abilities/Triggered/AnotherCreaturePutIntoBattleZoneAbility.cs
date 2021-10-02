using DuelMastersModels.Cards;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Zones;

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

        public override bool CanTrigger(GameEvent gameEvent, Duel duel)
        {
            if (gameEvent is CardChangedZoneEvent e)
            {
                return Source != e.Card && duel.GetCard(e.Card).CardType == CardType.Creature && e.DestinationZone == ZoneType.BattleZone;
            }
            else
            {
                return false;
            }

        }
    }
}
