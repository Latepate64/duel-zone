using System;

namespace DuelMastersModels.Abilities.Static
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
