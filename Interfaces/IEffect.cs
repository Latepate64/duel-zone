namespace Interfaces;

public interface IEffect
{
    IAbility? Ability { get; set; }
    IPlayer? Controller { get; }
    IPlayerV2 Applier { get; }
    ICard? Source { get; }
}
