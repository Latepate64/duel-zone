using System;

namespace DuelMastersModels.Abilities.Static
{
    public class AttacksIfAbleAbility : StaticAbility
    {
        public AttacksIfAbleAbility(Guid source) : base(source)
        {
        }

        public AttacksIfAbleAbility(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new AttacksIfAbleAbility(this);
        }
    }
}
