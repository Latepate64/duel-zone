using Interfaces;

namespace Abilities.Static;

/// <summary>
/// Power attacker +x (While attacking, this creature gets +x power.)
/// </summary>
internal class PowerAttackerAbility : StaticAbility, IPowerAttackerAbility
{
    public int Power { get; }

    internal PowerAttackerAbility(int power)
    {
        Power = power;
    }
}
