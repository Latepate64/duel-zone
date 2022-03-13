using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.Durations;

namespace Cards.Cards.DM01
{
    class CreepingPlague : Spell
    {
        public CreepingPlague() : base("Creeping Plague", 1, Common.Civilization.Darkness)
        {
            AddAbilities(new SpellAbility(new CreepingPlagueEffect()));
        }
    }

    class CreepingPlagueEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            // TODO: Now DelayedTriggeredAbility applies to any creature, should apply to own battle zone creatures only.
            game.AddDelayedTriggeredAbility(new TriggeredAbilities.BecomeBlockedAbility(new BlockedCreatureGetsAbilityEffect(new UntilTheEndOfTheTurn(), new SlayerAbility())), new UntilTheEndOfTheTurn());
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
