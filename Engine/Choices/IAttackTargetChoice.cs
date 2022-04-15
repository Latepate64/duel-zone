using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices
{
    public interface IAttackTargetChoice : IChoice
    {
        IAttackable Choice { get; set; }
        IEnumerable<IAttackable> Targets { get; set; }
    }

    public class AttackTargetChoice : Choice, IAttackTargetChoice
    {
        public AttackTargetChoice(IAttackTargetChoice choice) : base(choice)
        {
            Choice = choice.Choice;
            Targets = choice.Targets;
        }

        public AttackTargetChoice(IPlayer maker, IEnumerable<IAttackable> targets) : base(maker, "Choose a target for the attack.")
        {
            Targets = targets;
        }

        public IAttackable Choice { get; set; }
        public IEnumerable<IAttackable> Targets { get; set; }

        public override bool IsValid()
        {
            return Targets.Contains(Choice);
        }
    }
}
