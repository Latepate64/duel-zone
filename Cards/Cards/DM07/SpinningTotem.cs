using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;
using System;

namespace Cards.Cards.DM07
{
    class SpinningTotem : Creature
    {
        public SpinningTotem() : base("Spinning Totem", 5, 4000, Race.MysteryTotem, Civilization.Nature)
        {
            AddTapAbility(new SpinningTotemOneShotEffect());
        }
    }

    class SpinningTotemOneShotEffect : OneShotEffect
    {
        public SpinningTotemOneShotEffect()
        {
        }

        public SpinningTotemOneShotEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.AddDelayedTriggeredAbility(new SpinningTotemDelayedTriggeredAbility(Ability));
        }

        public override IOneShotEffect Copy()
        {
            return new SpinningTotemOneShotEffect(this);
        }

        public override string ToString()
        {
            return "This turn, whenever any of your nature creatures is attacking your opponent and becomes blocked, it breaks one of his shields.";
        }
    }

    class SpinningTotemDelayedTriggeredAbility : DelayedTriggeredAbility, IExpirable
    {
        public SpinningTotemDelayedTriggeredAbility(IAbility source) : base(new SpinningTotemTriggeredAbility(), source.Source, source.ControllerPlayer, false)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }

    class SpinningTotemTriggeredAbility : LinkedTriggeredAbility
    {
        private readonly ICard _breaker;

        public SpinningTotemTriggeredAbility() : base()
        {
        }

        public SpinningTotemTriggeredAbility(ICard breaker) : base()
        {
            _breaker = breaker;
        }

        public SpinningTotemTriggeredAbility(SpinningTotemTriggeredAbility ability) : base(ability)
        {
            _breaker = ability._breaker;
        }

        public override IAbility Copy()
        {
            return new SpinningTotemTriggeredAbility(this);
        }

        public override string ToString()
        {
            return "Whenever any of your nature creatures is attacking your opponent and becomes blocked, it breaks one of his shields.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            return new SpinningTotemTriggeredAbility((gameEvent as BecomeBlockedEvent).Attacker);
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is BecomeBlockedEvent e && e.Attacker.Owner == ControllerPlayer && e.Attacker.HasCivilization(Civilization.Nature);
        }

        public override void Resolve(IGame game)
        {
            game.Break(_breaker, 1);
        }
    }
}
