using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureAttacksEachTurnIfAbleEffect : ContinuousEffect, IAttacksIfAbleEffect
    {
        public ThisCreatureAttacksEachTurnIfAbleEffect() : base(new Engine.TargetFilter())
        {
        }

        public bool Applies(ICard creature, IGame game)
        {
            return creature.Id == game.GetAbility(SourceAbility).Source;
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