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
        public override void Apply(IGame game)
        {
            game.AddDelayedTriggeredAbility(new CreepingPlagueDelayedTriggeredAbility(Source));
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

    class CreepingPlagueDelayedTriggeredAbility : DelayedTriggeredAbility, IExpirable
    {
        public CreepingPlagueDelayedTriggeredAbility(IAbility source) : base(new CreepingPlagueTriggeredAbility(), source.Source, source.Controller, false)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
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
