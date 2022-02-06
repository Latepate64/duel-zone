using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class SlayerAbility : StaticAbility
    {
        public SlayerAbility()
        {
            ContinuousEffects.Add(new SlayerEffect());
        }
    }
}
