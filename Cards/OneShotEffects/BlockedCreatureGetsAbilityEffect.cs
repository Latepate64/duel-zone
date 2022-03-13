using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;
using Engine.Steps;
using System.Collections.Generic;

namespace Cards.OneShotEffects
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

        public override object Apply(Game game, Ability source)
        {
            if (game.CurrentTurn.CurrentPhase is AttackPhase phase && phase.AttackingCreature != System.Guid.Empty)
            {
                foreach (var ability in Abilities)
                {
                    game.AddContinuousEffects(source, new AbilityGrantingEffect(new TargetFilter { Target = phase.AttackingCreature }, new UntilTheEndOfTheTurn(), ability.Copy()));
                }
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new BlockedCreatureGetsAbilityEffect(this);
        }

        public override string ToString()
        {
            return $"It gets {string.Join(" and ", Abilities)} {Duration}.";
        }
    }
}