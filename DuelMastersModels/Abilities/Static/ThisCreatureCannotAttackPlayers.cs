using System;

namespace DuelMastersModels.Abilities.Static
{
    internal class ThisCreatureCannotAttackPlayers : StaticAbility
    {
        internal ThisCreatureCannotAttackPlayers(Guid source, Guid controller) : base(source, controller)
        { }

        public override Ability Copy()
        {
            throw new NotImplementedException();
        }
    }
}
