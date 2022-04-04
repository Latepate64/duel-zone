using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureAttacksEachTurnIfAbleEffect : ContinuousEffect, IAttacksIfAbleEffect
    {
        public ThisCreatureAttacksEachTurnIfAbleEffect() : base(new Engine.TargetFilter(), new Durations.Indefinite())
        {
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