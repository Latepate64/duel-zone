using System;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class ThisCreatureCannotAttackPlayers : StaticAbility
    {
        internal ThisCreatureCannotAttackPlayers(Guid source, Guid controller) : base(source, controller)
        { }

        public override StaticAbility Copy()
        {
            throw new NotImplementedException();
        }
    }
}
