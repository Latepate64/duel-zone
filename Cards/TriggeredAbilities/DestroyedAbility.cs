using Engine;
using Engine.Abilities;
using Engine.GameEvents;

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
            return gameEvent is CardMovedEvent e && e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && TriggersFrom(e.Card, game);
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

        protected override bool TriggersFrom(ICard card, IGame game)
        {
            return card.Id == Source;
        }
    }
}
