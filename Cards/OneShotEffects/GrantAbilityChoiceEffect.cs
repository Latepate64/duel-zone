using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class GrantAbilityChoiceEffect : CardSelectionEffect
    {
        public IEnumerable<Ability> Abilities { get; }
        public Duration Duration { get; }

        public GrantAbilityChoiceEffect(CardFilter filter, int minimum, int maximum, bool ownerChooses, params Ability[] ability) : base(filter, minimum, maximum, ownerChooses)
        {
            Abilities = ability;
            Duration = new UntilTheEndOfTheTurn();
        }

        public GrantAbilityChoiceEffect(GrantAbilityChoiceEffect effect) : base(effect)
        {
            Abilities = effect.Abilities;
            Duration = effect.Duration;
        }

        public override OneShotEffect Copy()
        {
            return new GrantAbilityChoiceEffect(this);
        }

        protected override void Apply(Game game, Ability source, IEnumerable<Card> cards)
        {
            foreach (var ability in Abilities)
            {
                game.ContinuousEffects.Add(new AbilityGrantingEffect(new TargetsFilter(cards.Select(x => x.Id)), Duration, ability.Copy()));
            }
        }

        public override string ToString()
        {
            return $"{GetAmountAsText()} of {Filter} gets {string.Join(", ", Abilities)} {Duration}{(ControllerChooses ? "" : "by your opponent's choice")}.";
        }
    }
}
