using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureHasSpeedAttackerEffect : ContinuousEffect, ISpeedAttackerEffect
    {
        public ThisCreatureHasSpeedAttackerEffect() : base(new Engine.TargetFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureHasSpeedAttackerEffect();
        }

        public override string ToString()
        {
            return "Speed attacker";
        }
    }
}