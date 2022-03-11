using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class UnchoosableAbility : StaticAbility
    {
        public UnchoosableAbility()
        {
            AddContinuousEffects(new UnchoosableEffect());
        }
    }
}
