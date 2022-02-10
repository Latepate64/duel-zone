using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class ChargerAbility : StaticAbility
    {
        public ChargerAbility()
        {
            ContinuousEffects.Add(new ChargerEffect());
        }
    }
}
