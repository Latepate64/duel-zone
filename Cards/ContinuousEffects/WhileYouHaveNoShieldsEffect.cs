using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WhileYouHaveNoShieldsEffect : AbilityAddingEffect
    {
        public WhileYouHaveNoShieldsEffect(params IAbility[] abilities) : base(new TargetFilter(), new Durations.Indefinite(), new Conditions.FilterNoneCondition(new CardFilters.OwnersShieldZoneCardFilter()), abilities)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new WhileYouHaveNoShieldsEffect();
        }

        public override string ToString()
        {
            return $"While you have no shields, this creature has {string.Join(" and ", Abilities.Select(x => $"\"{x.ToString()}\""))}.";
        }
    }
}