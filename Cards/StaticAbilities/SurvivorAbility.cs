using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    class SurvivorAbility : StaticAbility
    {
        public SurvivorAbility(IAbility ability) : base(new SurvivorEffect(ability))
        {
        }
    }

    class SurvivorEffect : AbilityAddingEffect
    {
        public SurvivorEffect(SurvivorEffect effect) : base(effect)
        {
        }

        public SurvivorEffect(IAbility ability) : base(new CardFilters.OwnersBattleZoneSubtypeCreatureFilter(Common.Subtype.Survivor), new Durations.Indefinite(), ability)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SurvivorEffect(this);
        }

        public override string ToString()
        {
            return $"Survivor : {AbilitiesAsText}";
        }
    }
}