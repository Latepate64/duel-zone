using Interfaces;

namespace Abilities.Static;

/// <summary>
/// Power attacker +x (While attacking, this creature gets +x power.)
/// </summary>
public class PowerAttackerAbility : StaticAbility, IPowerAttackerAbility
{
    public int Power { get; }

    internal PowerAttackerAbility(int power)
    {
        Power = power;
    }

    private PowerAttackerAbility(PowerAttackerAbility ability) : base(ability)
    {
        Power = ability.Power;
    }

    public override IAbility Copy()
    {
        return new PowerAttackerAbility(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not PowerAttackerAbility ability) return false;
        if (Power != ability.Power) return false;
        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Power);
        return hash.ToHashCode();
    }
}
