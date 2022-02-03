using Common;
using Common.GameEvents;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class WhenYouPutThisCreatureIntoTheBattleZoneAbility : CardChangesZoneAbility
    {
        public WhenYouPutThisCreatureIntoTheBattleZoneAbility(OneShotEffect effect) : base(effect)
        {
        }

        public WhenYouPutThisCreatureIntoTheBattleZoneAbility(WhenYouPutThisCreatureIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Engine.Game game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Destination == ZoneType.BattleZone && Source == e.CardInDestinationZone && game.GetCard(e.CardInDestinationZone).CardType == CardType.Creature && CheckInterveningIfClause(game);
            }
            else
            {
                return false;
            }
        }

        public override Ability Copy()
        {
            return new WhenYouPutThisCreatureIntoTheBattleZoneAbility(this);
        }
    }
}

