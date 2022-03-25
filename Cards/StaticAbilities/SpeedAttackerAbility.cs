using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class SpeedAttackerAbility : StaticAbility
    {
        public SpeedAttackerAbility() : base(new ThisCreatureHasSpeedAttackerEffect())
        {
        }
    }

    class ThisCreatureHasSpeedAttackerEffect : SpeedAttackerEffect
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

