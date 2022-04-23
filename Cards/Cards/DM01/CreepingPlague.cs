using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;
using System;

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
            game.AddDelayedTriggeredAbility(new CreepingPlagueDelayedTriggeredAbility(Ability));
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
        public CreepingPlagueDelayedTriggeredAbility(IAbility source) : base(new CreepingPlagueTriggeredAbility(), source.Source, source.ControllerPlayer, false)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }

    class CreepingPlagueTriggeredAbility : LinkedTriggeredAbility
    {
        private ICard _creature;

        public CreepingPlagueTriggeredAbility()
        {
        }

        public CreepingPlagueTriggeredAbility(CreepingPlagueTriggeredAbility ability) : base(ability)
        {
            _creature = ability._creature;
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is BecomeBlockedEvent e && e.Attacker == Source && ControllerPlayer == Source.Owner;
        }

        public override IAbility Copy()
        {
            return new CreepingPlagueTriggeredAbility(this);
        }

        public override void Resolve(IGame game)
        {
            game.AddContinuousEffects(this, new CreatureGetsSlayerUntilEndOfTheTurnEffect(_creature));
        }

        public override string ToString()
        {
            return "Whenever any of your creatures becomes blocked, it gets \"slayer\" until the end of the turn.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            _creature = (gameEvent as BecomeBlockedEvent).Attacker;
            return Copy() as ITriggeredAbility;
        }
    }
}
