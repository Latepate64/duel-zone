using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class CannotAttackCreaturesAbility : StaticAbility
    {
        public CannotAttackCreaturesAbility(params Engine.Condition[] conditions) : base(new CannotAttackCreaturesEffect(new Engine.TargetFilter(), conditions))
        {
        }
    }
}
