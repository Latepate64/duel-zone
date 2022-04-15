using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;

namespace Cards.Cards.DM01
{
    class CreepingPlague : Spell
    {
        public CreepingPlague() : base("Creeping Plague", 1, Civilization.Darkness)
        {
            AddSpellAbilities(new CreepingPlagueEffect());
        }
    }

    class CreepingPlagueEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddDelayedTriggeredAbility(new CreepingPlagueDelayedTriggeredAbility(source));
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

    class CreepingPlagueDelayedTriggeredAbility : DelayedTriggeredAbility, IDuration
    {
        public CreepingPlagueDelayedTriggeredAbility(IAbility source) : base(new CreepingPlagueTriggeredAbility(), source.Source, source.Controller, false)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }

    class CreepingPlagueTriggeredAbility : TriggeredAbilities.BecomeBlockedAbility
    {
        public CreepingPlagueTriggeredAbility() : base(new BlockedCreatureGetsSlayerUntilEndOfTheTurnEffect())
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

        protected override bool TriggersFrom(ICard card, IGame game)
        {
            return card.Owner == Controller;
        }
    }
}
