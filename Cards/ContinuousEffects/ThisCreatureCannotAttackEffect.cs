using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotAttackEffect : ContinuousEffect, ICannotAttackEffect
    {
        public ThisCreatureCannotAttackEffect() : base()
        {
        }

        public bool CannotAttack(ICard creature)
        {
            return IsSourceOfAbility(creature);
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotAttackEffect();
        }

        public override string ToString()
        {
            return "This creature can't attack.";
        }
    }
}