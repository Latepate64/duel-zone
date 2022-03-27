using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

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
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new CreepingPlagueTriggeredAbility(), source.Source, source.Owner, new Durations.UntilTheEndOfTheTurn(), false));
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

    class CreepingPlagueTriggeredAbility : TriggeredAbilities.BecomeBlockedAbility
    {
        public CreepingPlagueTriggeredAbility() : base(new BlockedCreatureGetsSlayerUntilEndOfTheTurnEffect(), new CardFilters.OwnersBattleZoneCreatureFilter())
        {
        }

        public override IAbility Copy()
        {
            return new CreepingPlagueTriggeredAbility();
        }

        public override string ToString()
        {
            return "Whenever any of your creatures becomes blocked, it gets \"slayer\" until the end of the turn.";
        }
    }
}
