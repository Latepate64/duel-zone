using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class SpeedAttackerAbility : StaticAbility
    {
        public SpeedAttackerAbility() : base(new ContinuousEffects.ThisCreatureHasSpeedAttackerEffect())
        {
        }
    }
}

