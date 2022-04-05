using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureHasSpeedAttackerEffect : ContinuousEffect, ISpeedAttackerEffect
    {
        public ThisCreatureHasSpeedAttackerEffect() : base(new Engine.TargetFilter())
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