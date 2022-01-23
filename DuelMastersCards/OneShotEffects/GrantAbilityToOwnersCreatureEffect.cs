using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class GrantAbilityToOwnersCreatureEffect : OneShotEffect
    {
        public IEnumerable<Ability> Abilities { get; }

        public GrantAbilityToOwnersCreatureEffect(params Ability[] ability)
        {
            Abilities = ability;
        }

        public GrantAbilityToOwnersCreatureEffect(GrantAbilityToOwnersCreatureEffect effect)
        {
            Abilities = effect.Abilities;
        }

        public override OneShotEffect Copy()
        {
            return new GrantAbilityToOwnersCreatureEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            var creatures = game.BattleZone.GetCreatures(source.Owner);
            if (creatures.Any())
            {
                var decision = game.GetPlayer(source.Owner).Choose(new GuidSelection(source.Owner, creatures, 1, 1));
                var target = game.GetCard(decision.Decision.Single()).Id;
                foreach (var ability in Abilities)
                {
                    game.ContinuousEffects.Add(new AbilityGrantingEffect(new TargetFilter { Target = target }, new UntilTheEndOfTheTurn(), ability.Copy()));
                }
            }
        }
    }
}
