using Engine.Abilities;
using System.Collections.Generic;

namespace Engine.Choices;

public interface IAbilityChoice : IChoice
{
    public IEnumerable<IResolvableAbility> Abilities { get; set; }
    public IResolvableAbility Choice { get; set; }
}