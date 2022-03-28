using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class ThisCreatureCanAttackUntappedCreaturesAbility : StaticAbility
    {
        public ThisCreatureCanAttackUntappedCreaturesAbility() : base(new ContinuousEffects.ThisCreatureCanAttackUntappedCreaturesEffect())
        {
        }
    }
}
