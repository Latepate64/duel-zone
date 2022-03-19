using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class DestroyedAbility : CardChangesZoneAbility
    {
        public DestroyedAbility(OneShotEffect effect) : base(effect)
        {
        }

        public DestroyedAbility(DestroyedAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is CardMovedEvent e && e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard;
        }

        public override Ability Copy()
        {
            return new DestroyedAbility(this);
        }

        public override string ToString()
        {
            return $"When ${Filter} is destroyed, {ToStringBase()}";
        }
    }
}
