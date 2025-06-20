using ContinuousEffects;
using Engine.Abilities;

namespace Abilities.Static;

public class PowerAttackerAbility(int power) : StaticAbility(new PowerAttackerEffect(power))
{
}
