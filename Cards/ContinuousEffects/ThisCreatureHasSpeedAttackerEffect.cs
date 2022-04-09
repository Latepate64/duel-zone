using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureHasSpeedAttackerEffect : ContinuousEffect, ISpeedAttackerEffect
    {
        public ThisCreatureHasSpeedAttackerEffect() : base()
        {
        }

        public bool Applies(ICard creature, IGame game)
        {
            return IsSourceOfAbility(creature, game);
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