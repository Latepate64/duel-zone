using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureCannotAttackCreaturesEffect : ContinuousEffect, ICannotAttackCreaturesEffect
    {
        public ThisCreatureCannotAttackCreaturesEffect() : base()
        {
        }

        public bool CannotAttackCreature(ICard attacker, ICard target, IGame game)
        {
            return IsSourceOfAbility(attacker, game);
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