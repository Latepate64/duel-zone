using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    class WhenThisCreatureLeavesBattleZoneAbility : TriggeredAbility
    {
        public WhenThisCreatureLeavesBattleZoneAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WhenThisCreatureLeavesBattleZoneAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is CardMovedEvent e && e.Source == ZoneType.BattleZone && game.GetCard(e.CardInSourceZone) == Source;
        }

        public override IAbility Copy()
        {
            return new WhenThisCreatureLeavesBattleZoneAbility(this);
        }

        public override string ToString()
        {
            return $"When this creature leaves the battle Zone, {GetEffectText()}";
        }
    }
}
