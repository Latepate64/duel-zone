using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class SkipBattleAfterBecomesBlockedEffect : ContinuousEffect, ISkipBattleAfterBlockEffect
    {
        public SkipBattleAfterBecomesBlockedEffect()
        {
        }

        public SkipBattleAfterBecomesBlockedEffect(SkipBattleAfterBecomesBlockedEffect effect) : base(effect)
        {
        }

        public bool Applies(ICard attacker, ICard blocker, IGame game)
        {
            return attacker == Source;
        }

        public override IContinuousEffect Copy()
        {
            return new SkipBattleAfterBecomesBlockedEffect(this);
        }

        public override string ToString()
        {
            return "Whenever this creature becomes blocked, no battle happens.";
        }
    }
}
