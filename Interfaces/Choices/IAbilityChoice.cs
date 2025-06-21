namespace Interfaces.Choices;

public interface IAbilityChoice : IChoice
{
    public IEnumerable<IResolvableAbility> Abilities { get; set; }
    public IResolvableAbility Choice { get; set; }
}
