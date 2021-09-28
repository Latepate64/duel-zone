using System;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class ThisCreatureAttacksEachTurnIfAble : StaticAbility
    {
        internal ThisCreatureAttacksEachTurnIfAble(Guid source, Guid controller) : base(source, controller)
        { }

        public override Ability Copy()
        {
            throw new NotImplementedException();
        }
    }
}
