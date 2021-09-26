using System;

namespace DuelMastersModels.Abilities
{
    public abstract class SpellAbility : NonStaticAbility
    {
        protected SpellAbility(Guid source, Guid controller) : base(source, controller)
        { }

        protected SpellAbility(SpellAbility ability) : base(ability)
        { }
    }
}
