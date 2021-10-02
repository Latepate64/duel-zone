using System;

namespace DuelMastersModels.Abilities.Static
{
    internal class ThisCreatureCannotAttackPlayers : StaticAbility
    {
        internal ThisCreatureCannotAttackPlayers(Guid source) : base(source)
        { }

        public override Ability Copy()
        {
            throw new NotImplementedException();
        }
    }
}
