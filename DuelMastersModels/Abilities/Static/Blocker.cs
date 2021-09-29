using System;

namespace DuelMastersModels.Abilities.Static
{
    internal class Blocker : StaticAbility
    {
        internal Blocker(Guid source, Guid controller) : base(source, controller)
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
