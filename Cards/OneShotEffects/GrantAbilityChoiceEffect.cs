using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class GrantAbilityChoiceEffect : GrantChoiceEffect
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
                game.AddContinuousEffects(source, new AbilityGrantingEffect(new TargetsFilter(cards.Select(x => x.Id).ToArray()), Duration, ability.Copy()));
            }
        }

        public override string ToString()
        {
            return $"{GetAmountAsText()} of {Filter} gets {string.Join(", ", Abilities)} {Duration}{(ControllerChooses ? "" : "by your opponent's choice")}.";
        }
    }
}
