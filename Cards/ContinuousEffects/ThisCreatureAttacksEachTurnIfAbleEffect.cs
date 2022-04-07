using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureAttacksEachTurnIfAbleEffect : ContinuousEffect, IAttacksIfAbleEffect
    {
        public ThisCreatureAttacksEachTurnIfAbleEffect() : base()
        {
        }

        public bool Applies(ICard creature, IGame game)
        {
            return IsSourceOfAbility(creature, game);
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureAttacksEachTurnIfAbleEffect();
        }

        public override string ToString()
        {
            return "This creature attacks each turn if able.";
        }
    }
}