using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotBeAttackedEffect : ContinuousEffect, ICannotBeAttackedEffect
    {
        public ThisCreatureCannotBeAttackedEffect() : base()
        {
        }

        public bool Applies(ICard attacker, ICard targetOfAttack)
        {
            return IsSourceOfAbility(targetOfAttack);
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeAttackedEffect();
        }

        public override string ToString()
        {
            return "This creature can't be attacked.";
        }
    }
}