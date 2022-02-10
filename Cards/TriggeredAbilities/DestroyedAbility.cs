using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    class DestroyedAbility : CardChangesZoneAbility
    {
        public DestroyedAbility(OneShotEffect effect) : base(effect)
        {
        }

        public DestroyedAbility(DestroyedAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Game game)
        {
            return gameEvent is CardMovedEvent e && e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && Source == e.CardInDestinationZone.Id && game.GetCard(e.CardInDestinationZone.Id).CardType == CardType.Creature && CheckInterveningIfClause(game);
        }

        public override Ability Copy()
        {
            return new DestroyedAbility(this);
        }

        public override string ToString()
        {
            return $"When this creature is destroyed, {ToStringBase()}";
        }
    }
}
