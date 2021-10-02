using System;

namespace DuelMastersModels.Abilities.Static
{
    internal class ThisCreatureAttacksEachTurnIfAble : StaticAbility
    {
        internal ThisCreatureAttacksEachTurnIfAble(Guid source) : base(source)
        { }

        public override Ability Copy()
        {
            throw new NotImplementedException();
        }
    }
}
