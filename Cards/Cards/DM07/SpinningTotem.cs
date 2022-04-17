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
        public override object Apply(IGame game, IAbility source)
        {
            game.AddDelayedTriggeredAbility(new SpinningTotemDelayedTriggeredAbility(source));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new SpinningTotemOneShotEffect();
        }

        public override string ToString()
        {
            return "This turn, whenever any of your nature creatures is attacking your opponent and becomes blocked, it breaks one of his shields.";
        }
    }

    class SpinningTotemDelayedTriggeredAbility : DelayedTriggeredAbility, IExpirable
    {
        public SpinningTotemDelayedTriggeredAbility(IAbility source) : base(new SpinningTotemTriggeredAbility(), source.Source, source.Controller, false)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }

    class SpinningTotemTriggeredAbility : BecomeBlockedAbility
    {
        public SpinningTotemTriggeredAbility() : base(new OneShotEffects.TargetCreatureBreaksOpponentsShieldsEffect(1, null))
        {
        }

        public SpinningTotemTriggeredAbility(SpinningTotemTriggeredAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new SpinningTotemTriggeredAbility(this);
        }

        public override string ToString()
        {
            return "Whenever any of your nature creatures is attacking your opponent and becomes blocked, it breaks one of his shields.";
        }

        protected override bool TriggersFrom(ICard card, IGame game)
        {
            return card.Owner == GetController(game).Id && card.HasCivilization(Civilization.Nature);
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            var ability = base.Trigger(source, owner, gameEvent);
            ability.OneShotEffect = new OneShotEffects.TargetCreatureBreaksOpponentsShieldsEffect(1, (gameEvent as BecomeBlockedEvent).Attacker);
            return ability;
        }
    }
}
