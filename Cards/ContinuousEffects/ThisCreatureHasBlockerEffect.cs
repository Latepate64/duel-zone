using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureHasBlockerEffect : ContinuousEffect, IBlockerEffect
    {
        public ThisCreatureHasBlockerEffect() : base()
        {
        }

        public bool CanBlock(Card blocker, Card attacker, IGame game)
        {
            return IsSourceOfAbility(blocker);
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureHasBlockerEffect();
        }

        public override string ToString()
        {
            return "Blocker";
        }
    }
}
