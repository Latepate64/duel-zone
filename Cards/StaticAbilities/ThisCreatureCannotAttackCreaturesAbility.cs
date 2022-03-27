using Engine;
using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class ThisCreatureCannotAttackCreaturesAbility : StaticAbility
    {
        public ThisCreatureCannotAttackCreaturesAbility(params Condition[] conditions) : base(new ContinuousEffects.ThisCreatureCannotAttackCreaturesEffect(conditions))
        {
        }
    }
}
