using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class OpponentCannotChooseThisCreatureEffect : ContinuousEffect, IUnchoosableEffect
    {
        public OpponentCannotChooseThisCreatureEffect() : base()
        {
        }

        public bool Applies(ICard creature, IGame game)
        {
            return IsSourceOfAbility(creature, game);
        }

        public override IContinuousEffect Copy()
        {
            return new OpponentCannotChooseThisCreatureEffect();
        }

        public override string ToString()
        {
            return "Whenever your opponent would choose a creature in the battle zone, he can't choose this one.";
        }
    }
}