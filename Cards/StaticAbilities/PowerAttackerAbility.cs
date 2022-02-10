using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class PowerAttackerAbility : StaticAbility
    {
        public PowerAttackerAbility(int power)
        {
            ContinuousEffects.Add(new PowerAttackerEffect(power));
        }
    }
}
