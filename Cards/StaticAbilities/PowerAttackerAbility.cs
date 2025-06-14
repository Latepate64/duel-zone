using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class PowerAttackerAbility(int power) : StaticAbility(new PowerAttackerEffect(power))
    {
    }
}
