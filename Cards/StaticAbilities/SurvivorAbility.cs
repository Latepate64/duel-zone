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

    class SurvivorEffect : ContinuousEffect
    {
        private readonly IAbility _ability;

        public SurvivorEffect(SurvivorEffect effect) : base(effect)
        {
            _ability = effect._ability.Copy();
        }

        public SurvivorEffect(IAbility ability) : base(new CardFilters.OwnersBattleZoneSubtypeCreatureFilter(Common.Subtype.Survivor))
        {
            _ability = ability;
        }

        public override IContinuousEffect Copy()
        {
            return new SurvivorEffect(this);
        }

        public override string ToString()
        {
            return $"Survivor (Each of your Survivors has this creature's Survivor ability.) : {_ability}";
        }
    }
}