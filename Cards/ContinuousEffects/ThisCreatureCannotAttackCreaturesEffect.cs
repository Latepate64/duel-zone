using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureCannotAttackCreaturesEffect : ContinuousEffect, ICannotAttackCreaturesEffect
    {
        public ThisCreatureCannotAttackCreaturesEffect() : base()
        {
        }

        public bool Applies(ICard creature, IGame game)
        {
            return IsSourceOfAbility(creature, game);
        }

        public override ContinuousEffect Copy()
        {
            return new ThisCreatureCannotAttackCreaturesEffect();
        }

        public override string ToString()
        {
            return "This creature can't attack creatures.";
        }
    }
}