using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.Durations;

namespace Cards.OneShotEffects
{
    class CreepingPlagueEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            // TODO: Now DelayedTriggeredAbility applies to any creature, should apply to own battle zone creatures only.
            game.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(new TriggeredAbilities.BecomeBlockedAbility(new BlockedCreatureGetsAbilityEffect(new UntilTheEndOfTheTurn(), new SlayerAbility())), new UntilTheEndOfTheTurn(), source.Source, source.Owner));
        }

        public override OneShotEffect Copy()
        {
            return new CreepingPlagueEffect();
        }

        public override string ToString()
        {
            return "Whenever any of your creatures becomes blocked this turn, it gets \"slayer\" until the end of the turn.";
        }
    }
}