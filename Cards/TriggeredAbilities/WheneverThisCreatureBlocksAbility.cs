using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    class WheneverThisCreatureBlocksAbility : CardTriggeredAbility
    {
        public WheneverThisCreatureBlocksAbility(OneShotEffect effect) : base(effect)
        {
        }

        public WheneverThisCreatureBlocksAbility(WheneverThisCreatureBlocksAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is BlockEvent;
        }

        public override Ability Copy()
        {
            return new WheneverThisCreatureBlocksAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever this creature blocks, {OneShotEffect}.";
        }

        protected override bool TriggersFrom(Engine.ICard card, IGame game)
        {
            return card.Id == Source;
        }
    }
}