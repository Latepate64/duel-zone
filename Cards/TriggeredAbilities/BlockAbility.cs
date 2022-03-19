using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    class BlockAbility : CardTriggeredAbility
    {
        public BlockAbility(OneShotEffect effect) : base(effect)
        {
        }

        public BlockAbility(BlockAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is BlockEvent;
        }

        public override Ability Copy()
        {
            return new BlockAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever this creature blocks, {OneShotEffect}.";
        }
    }
}