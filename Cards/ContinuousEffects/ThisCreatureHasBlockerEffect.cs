using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureHasBlockerEffect : ContinuousEffect, IBlockerEffect
    {
        public ThisCreatureHasBlockerEffect() : base(new TargetFilter(), new Durations.Indefinite())
        {
        }

        public bool Applies(ICard attacker, IGame game)
        {
            return true;
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
