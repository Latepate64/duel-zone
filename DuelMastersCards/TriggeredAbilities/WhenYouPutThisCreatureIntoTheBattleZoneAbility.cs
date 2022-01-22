using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Zones;

namespace DuelMastersCards.TriggeredAbilities
{
    public class WhenYouPutThisCreatureIntoTheBattleZoneAbility : CardChangesZoneAbility
    {
        public WhenYouPutThisCreatureIntoTheBattleZoneAbility(OneShotEffect effect) : base(effect)
        {
        }

        public WhenYouPutThisCreatureIntoTheBattleZoneAbility(WhenYouPutThisCreatureIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Game game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Destination == ZoneType.BattleZone && Source == e.CardInDestinationZone && game.GetCard(e.CardInDestinationZone).CardType == CardType.Creature;
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

