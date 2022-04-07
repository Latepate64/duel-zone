using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureHasSlayerEffect : ContinuousEffect, ISlayerEffect
    {
        public ThisCreatureHasSlayerEffect(ThisCreatureHasSlayerEffect effect) : base(effect)
        {
        }

        public ThisCreatureHasSlayerEffect() : base()
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

        public bool Applies(ICard creature, ICard against, IGame game)
        {
            return IsSourceOfAbility(creature, game);
        }
    }
}