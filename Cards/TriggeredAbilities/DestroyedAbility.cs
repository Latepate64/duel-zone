using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public abstract class DestroyedAbility : CardChangesZoneAbility
    {
        protected DestroyedAbility(IOneShotEffect effect) : base(effect)
        {
        }

        protected DestroyedAbility(DestroyedAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is CardMovedEvent e && e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard;
        }
    }

    public class WhenThisCreatureIsDestroyedAbility : DestroyedAbility
    {
        public WhenThisCreatureIsDestroyedAbility(WhenThisCreatureIsDestroyedAbility ability) : base(ability)
        {
        }

        public WhenThisCreatureIsDestroyedAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public override IAbility Copy()
        {
            return new WhenThisCreatureIsDestroyedAbility(this);
        }

        public override string ToString()
        {
            return $"When this creature is destroyed, {GetEffectText()}";
        }

        protected override bool TriggersFrom(Engine.ICard card, IGame game)
        {
            return card.Id == Source;
        }
    }
}
