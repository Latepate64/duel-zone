using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class PowerAttackerAbility : StaticAbility
    {
        public PowerAttackerAbility(int power, params Engine.Condition[] conditions) : base(new PowerAttackerEffect(power, conditions))
        {
        }
    }
}
