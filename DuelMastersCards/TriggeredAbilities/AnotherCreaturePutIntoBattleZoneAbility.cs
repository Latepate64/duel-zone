using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Zones;

namespace DuelMastersCards.TriggeredAbilities
{
    public class AnotherCreaturePutIntoBattleZoneAbility : CardChangesZoneAbility
    {
        public AnotherCreaturePutIntoBattleZoneAbility(Resolvable resolvable) : base(resolvable)
        {
        }

        public AnotherCreaturePutIntoBattleZoneAbility(AnotherCreaturePutIntoBattleZoneAbility ability) : base(ability)
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

        public override Ability Copy()
        {
            return new AnotherCreaturePutIntoBattleZoneAbility(this);
        }
    }
}
