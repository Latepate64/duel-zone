using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class CanAttackUntappedCreaturesAbility : StaticAbility
    {
        public CanAttackUntappedCreaturesAbility()
        {
            ContinuousEffects.Add(new CanAttackUntappedCreaturesEffect());
        }
    }
}
