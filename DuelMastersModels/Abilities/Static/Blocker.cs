using System;

namespace DuelMastersModels.Abilities.Static
{
    public class Blocker : StaticAbility
    {
        internal Blocker(Guid source) : base(source)
        {
        }

        public Blocker(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new Blocker(this);
        }
    }
}
