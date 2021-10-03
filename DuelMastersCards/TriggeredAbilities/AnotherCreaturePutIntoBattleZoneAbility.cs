using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Zones;

namespace DuelMastersCards.TriggeredAbilities
{
    public abstract class AnotherCreaturePutIntoBattleZoneAbility : CardChangesZoneAbility
    {
        protected AnotherCreaturePutIntoBattleZoneAbility()
        {
        }

        protected AnotherCreaturePutIntoBattleZoneAbility(AnotherCreaturePutIntoBattleZoneAbility ability) : base(ability)
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
