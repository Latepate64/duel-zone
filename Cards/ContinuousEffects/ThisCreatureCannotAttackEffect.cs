using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotAttackEffect : ContinuousEffect, ICannotAttackEffect
    {
        public ThisCreatureCannotAttackEffect() : base(new TargetFilter())
        {
        }

        public bool Applies(IGame game)
        {
            return true;
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