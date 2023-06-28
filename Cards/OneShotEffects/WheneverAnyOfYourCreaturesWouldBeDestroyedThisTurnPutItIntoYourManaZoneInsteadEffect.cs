using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;

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

        public override void Apply()
        {
            Game.AddContinuousEffects(Ability, new WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
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

        public WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect() : base()
        {
        }

        public WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent)
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

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }

        public override string ToString()
        {
            return "Whenever any of your creatures would be destroyed, put it into your mana zone instead.";
        }

        protected override bool Applies(ICard card)
        {
            return card.Owner == Applier;
        }
    }
}