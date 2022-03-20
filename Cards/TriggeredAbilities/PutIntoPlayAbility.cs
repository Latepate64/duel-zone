using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class PutIntoPlayAbility : CardChangesZoneAbility
    {
        /// <summary>
        /// Source of the ability is put into the battle zone.
        /// </summary>
        /// <param name="effect"></param>
        public PutIntoPlayAbility(IOneShotEffect effect) : base(effect)
        {
        }

        /// <summary>
        /// Card matching the filter is put into the battle zone.
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="filter"></param>
        public PutIntoPlayAbility(IOneShotEffect effect, ICardFilter filter) : base(effect, filter)
        {
        }

        public PutIntoPlayAbility(PutIntoPlayAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is CardMovedEvent e && e.Destination == ZoneType.BattleZone;
        }

        public override Ability Copy()
        {
            return new PutIntoPlayAbility(this);
        }

        public override string ToString()
        {
            return $"When ${Filter} is put into the battle zone, {ToStringBase()}";
        }
    }
}

