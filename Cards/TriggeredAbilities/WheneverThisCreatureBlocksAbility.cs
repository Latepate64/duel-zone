using Engine;
using Engine.Abilities;
using Engine.GameEvents;

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
            throw new System.NotImplementedException();
            //return base.CanTrigger(gameEvent, game) && gameEvent is BlockEvent;
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