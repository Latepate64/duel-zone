using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using Engine.Durations;

namespace Cards.Cards.DM01
{
    class CreepingPlague : Spell
    {
        public CreepingPlague() : base("Creeping Plague", 1, Common.Civilization.Darkness)
        {
            AddSpellAbilities(new CreepingPlagueEffect());
        }
    }

    class CreepingPlagueEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            // TODO: Now DelayedTriggeredAbility applies to any creature, should apply to own battle zone creatures only.
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new TriggeredAbilities.BecomeBlockedAbility(new BlockedCreatureGetsSlayerUntilEndOfTheTurnEffect()), source.Source, source.Owner, new UntilTheEndOfTheTurn()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new CreepingPlagueEffect();
        }

        public override string ToString()
        {
            return "Whenever any of your creatures becomes blocked this turn, it gets \"slayer\" until the end of the turn.";
        }
    }
}
