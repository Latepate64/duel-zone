using Common;
using Common.GameEvents;
using Engine.Abilities;

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

        public override bool CanTrigger(GameEvent gameEvent, Engine.Game game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Destination == ZoneType.BattleZone && Source != e.CardInDestinationZone.Id && game.GetCard(e.CardInDestinationZone.Id).CardType == CardType.Creature && CheckInterveningIfClause(game);
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
