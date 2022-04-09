using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class PowerAttackerAbility : StaticAbility
    {
        public PowerAttackerAbility(int power) : base(new PowerAttackerEffect(power))
        {
        }
    }
}
