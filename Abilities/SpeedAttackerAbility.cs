using Interfaces;

namespace Abilities;

/// <summary>
/// Speed attacker (This creature doesn't get summoning sickness.)
/// </summary>
public class SpeedAttackerAbility : StaticAbility, ISpeedAttackerAbility
{
    public SpeedAttackerAbility()
    {
    }

    public SpeedAttackerAbility(SpeedAttackerAbility ability) : base(ability)
    {
    }

    public bool Applies(ICreature creature, IGame game)
    {
        if (creature.Equals(Source)) return true;
        return false;
    }

    public override IAbility Copy()
    {
        return new SpeedAttackerAbility(this);
    }
}