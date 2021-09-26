using System;

namespace DuelMastersModels.Abilities
{
    internal abstract class SpellAbility : NonStaticAbility
    {
        internal SpellAbility(Guid source, Guid controller) : base(source, controller)
        { }
    }
}
