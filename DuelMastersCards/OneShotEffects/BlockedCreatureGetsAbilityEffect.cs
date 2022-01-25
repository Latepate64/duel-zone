using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using DuelMastersModels.Steps;
using System.Collections.Generic;

namespace DuelMastersCards.OneShotEffects
{
    class BlockedCreatureGetsAbilityEffect : OneShotEffect
    {
        public Duration Duration { get; set; }

        public IEnumerable<Ability> Abilities { get; }

        public BlockedCreatureGetsAbilityEffect(Duration duration, params Ability[] abilities)
        {
            Duration = duration;
            Abilities = abilities;
        }

        public BlockedCreatureGetsAbilityEffect(BlockedCreatureGetsAbilityEffect effect)
        {
            Duration = effect.Duration;
            Abilities = effect.Abilities;
        }

        public override void Apply(Game game, Ability source)
        {
            if (game.CurrentTurn.CurrentPhase is AttackPhase phase && phase.AttackingCreature != System.Guid.Empty)
            {
                foreach (var ability in Abilities)
                {
                    game.ContinuousEffects.Add(new AbilityGrantingEffect(new TargetFilter { Target = phase.AttackingCreature }, new UntilTheEndOfTheTurn(), ability.Copy()));
                }
            }
        }

        public override OneShotEffect Copy()
        {
            return new BlockedCreatureGetsAbilityEffect(this);
        }
    }
}