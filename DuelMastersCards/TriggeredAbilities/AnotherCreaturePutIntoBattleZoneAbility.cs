using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Zones;

namespace Cards.TriggeredAbilities
{
    public class AnotherCreaturePutIntoBattleZoneAbility : CardChangesZoneAbility
    {
        public AnotherCreaturePutIntoBattleZoneAbility(OneShotEffect effect) : base(effect)
        {
        }

        public AnotherCreaturePutIntoBattleZoneAbility(AnotherCreaturePutIntoBattleZoneAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Game game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Destination == ZoneType.BattleZone && Source != e.CardInDestinationZone && game.GetCard(e.CardInDestinationZone).CardType == CardType.Creature && CheckInterveningIfClause(game);
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
