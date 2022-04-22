using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;
using System;

namespace Cards.OneShotEffects
{
    class WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect : OneShotEffect
    {
        public WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect()
        {
        }

        public WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(Ability.Controller));
        }

        public override IOneShotEffect Copy()
        {
            return new WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect(this);
        }

        public override string ToString()
        {
            return "Whenever any of your creatures would be destroyed this turn, put it into your mana zone instead.";
        }
    }


    class WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : DestructionReplacementEffect, IExpirable
    {
        private readonly Guid _controller;

        public WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(Guid controller) : base()
        {
            _controller = controller;
        }

        public WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect effect) : base(effect)
        {
            _controller = effect._controller;
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                Destination = ZoneType.ManaZone
            };
        }

        public override IContinuousEffect Copy()
        {
            return new WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(this);
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }

        public override string ToString()
        {
            return "Whenever any of your creatures would be destroyed, put it into your mana zone instead.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return card.Owner == _controller;
        }
    }
}