using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureHasSlayerEffect : ContinuousEffect, ISlayerEffect
    {
        public ThisCreatureHasSlayerEffect(ThisCreatureHasSlayerEffect effect) : base(effect)
        {
        }

        public ThisCreatureHasSlayerEffect() : base(new TargetFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureHasSlayerEffect();
        }

        public override string ToString()
        {
            return "Slayer";
        }

        public bool Applies(ICard against)
        {
            return true;
        }
    }
}