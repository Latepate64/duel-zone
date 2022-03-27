using Engine.Abilities;

namespace Cards.StaticAbilities
{
    class SurvivorAbility : StaticAbility
    {
        public SurvivorAbility(IAbility ability) : base(new ContinuousEffects.SurvivorEffect(ability))
        {
        }
    }
}