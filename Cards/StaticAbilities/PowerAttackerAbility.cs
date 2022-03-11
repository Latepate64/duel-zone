using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class PowerAttackerAbility : StaticAbility
    {
        public PowerAttackerAbility(int power)
        {
            AddContinuousEffects(new PowerAttackerEffect(power));
        }
    }
}
