using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices
{
    public interface IAbilityChoice : IChoice
    {
        public IEnumerable<IResolvableAbility> Abilities { get; set; }
        public IResolvableAbility Choice { get; set; }
    }

    public class AbilityChoice : Choice, IAbilityChoice
    {
        public AbilityChoice(IAbilityChoice choice) : base(choice)
        {
            Abilities = choice.Abilities;
            Choice = choice.Choice;
        }

        public AbilityChoice(IPlayer maker, IEnumerable<IResolvableAbility> abilities) : base(maker, "Choose an ability to resolve.")
        {
            Abilities = abilities;
        }

        public IEnumerable<IResolvableAbility> Abilities { get; set; }
        public IResolvableAbility Choice { get; set; }

        public override bool IsValid()
        {
            return Abilities.Contains(Choice);
        }
    }
}
