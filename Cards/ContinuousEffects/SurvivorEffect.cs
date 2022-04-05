using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class SurvivorEffect : AbilityAddingEffect
    {
        public SurvivorEffect(SurvivorEffect effect) : base(effect)
        {
        }

        public SurvivorEffect(IAbility ability) : base(new CardFilters.OwnersBattleZoneSubtypeCreatureFilter(Common.Subtype.Survivor), ability)
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