namespace Interfaces;

public interface IEffect
{
    IAbility Ability { get; set; }
    IPlayer Controller { get; }
    ICard Source { get; }
}
