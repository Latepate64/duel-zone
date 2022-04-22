using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureBlocksIfAble : ContinuousEffect, IBlocksIfAbleEffect
    {
        public ThisCreatureBlocksIfAble() : base()
        {
        }

        public bool BlocksIfAble(ICard blocker, ICard attacker, IGame game)
        {
            return IsSourceOfAbility(blocker);
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