using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    class CreatureBlockedAbility : TriggeredAbility
    {
        public CreatureBlockedAbility(CreatureBlockedAbility ability) : base(ability)
        {
        }

        public CreatureBlockedAbility(OneShotEffect effect) : base(effect)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Game game)
        {
            return gameEvent is BlockEvent;
        }

        public override Ability Copy()
        {
            return new CreatureBlockedAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever a creature becomes blocked, {OneShotEffect}";
        }
    }
}
