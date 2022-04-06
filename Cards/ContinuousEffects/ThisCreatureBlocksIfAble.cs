using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureBlocksIfAble : ContinuousEffect, IBlocksIfAbleEffect
    {
        public ThisCreatureBlocksIfAble() : base(new TargetFilter())
        {
        }

        public bool Applies(ICard creature, IGame game)
        {
            return IsSourceOfAbility(creature, game);
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureBlocksIfAble();
        }

        public override string ToString()
        {
            return "Whenever an opponent's creature attacks, this creature blocks if able.";
        }
    }
}