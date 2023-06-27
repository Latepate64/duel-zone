using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class OpponentCannotChooseThisCreatureEffect : ContinuousEffect, IPlayerCannotChooseCreatureEffect
    {
        public OpponentCannotChooseThisCreatureEffect() : base()
        {
        }

        public bool PlayerCannotChooseCreature(ICard creature, System.Guid player, IGame game)
        {
            return IsSourceOfAbility(creature) && player == game.GetOpponent(Applier).Id;
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