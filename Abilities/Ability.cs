using Interfaces;

namespace Abilities;

public abstract class Ability : IAbility
{
    public ICard Source { get; set; }

    public IPlayer Controller { get; set; }

    protected Ability()
    {
    }

    protected Ability(IAbility ability)
    {
        Controller = ability.Controller;
        Source = ability.Source?.Copy();
    }

    public abstract IAbility Copy();

    public override bool Equals(object? obj)
    {
        if (obj is not Ability ability) return false;
        if (Source == null && ability.Source != null) return false;
        if (Source != null && !Source.Equals(ability.Source)) return false;
        if (Controller == null && ability.Controller != null) return false;
        if (Controller != null && !Controller.Equals(ability.Controller)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Source, Controller);
    }
}
