using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class GrantAbilityToOwnersCreatureEffect : OneShotEffect
    {
        public Ability Ability { get; }

        public GrantAbilityToOwnersCreatureEffect(Ability ability)
        {
            Ability = ability;
        }

        public GrantAbilityToOwnersCreatureEffect(GrantAbilityToOwnersCreatureEffect effect)
        {
            Ability = effect.Ability;
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
                game.ContinuousEffects.Add(new AbilityGrantingEffect(new TargetFilter { Target = target }, new UntilTheEndOfTheTurn(), Ability.Copy()));
            }
        }
    }
}
