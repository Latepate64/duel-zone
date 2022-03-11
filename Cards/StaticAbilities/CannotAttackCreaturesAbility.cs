using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class CannotAttackCreaturesAbility : StaticAbility
    {
        public CannotAttackCreaturesAbility() : base()
        {
            AddContinuousEffects(new CannotAttackCreaturesEffect());
        }
    }
}
