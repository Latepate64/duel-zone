using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class SpeedAttackerAbility : StaticAbility
    {
        public SpeedAttackerAbility() : base()
        {
            ContinuousEffects.Add(new SpeedAttackerEffect());
        }
    }
}

