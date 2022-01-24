using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class GrantAbilityChoiceEffect : CardSelectionEffect
    {
        public IEnumerable<Ability> Abilities { get; }

        public GrantAbilityChoiceEffect(CardFilter filter, int minimum, int maximum, bool ownerChooses, params Ability[] ability) : base(filter, minimum, maximum, ownerChooses)
        {
            Abilities = ability;
        }

        public GrantAbilityChoiceEffect(GrantAbilityChoiceEffect effect) : base(effect)
        {
            Abilities = effect.Abilities;
        }

        public override OneShotEffect Copy()
        {
            return new GrantAbilityChoiceEffect(this);
        }

        protected override void Apply(Game game, Ability source, IEnumerable<Card> cards)
        {
            foreach (var ability in Abilities)
            {
                game.ContinuousEffects.Add(new AbilityGrantingEffect(new TargetsFilter(cards.Select(x => x.Id)), new UntilTheEndOfTheTurn(), ability.Copy()));
            }
        }
    }
}
