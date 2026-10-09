using Interfaces;

namespace Abilities;

/// <summary>
/// An ability can be one of three things: An ability can be a characteristic an
/// object has that lets it affect the game; An ability can be something that a
/// player has that changes how the game affects the player.; An ability can be
/// an activated or triggered ability on the stack.
/// </summary>
public abstract class Ability : IAbility
{
    public Guid Id { get; }

    public ICard Source { get; set; }

    /// <summary>
    /// 113.8.
    /// The controller of an activated ability on the stack is the player who
    /// activated it.
    /// The controller of a triggered ability on the stack (other than a delayed
    /// triggered ability)
    /// is the player who controlled the ability’s source when it triggered, or,
    /// if it had no controller,
    /// the player who owned the ability’s source when it triggered.
    /// </summary>
    public IPlayer Controller { get; set; }

    protected Ability()
    {
        Id = Guid.NewGuid();
    }

    protected Ability(IAbility ability)
    {
        Id = Guid.NewGuid();
        Controller = ability.Controller;
        Source = ability.Source;
    }

    public abstract IAbility Copy();

    public override bool Equals(object? obj)
    {
        if (obj is not Ability ability) return false;
        // Do not check Id as it should be removed anyway
        if (Source == null && ability.Source != null) return false;
        if (Source != null && !Source.Equals(ability.Source)) return false;
        if (Controller == null && ability.Controller != null) return false;
        if (Controller != null && !Controller.Equals(
            ability.Controller)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Source, Controller);
    }
}
