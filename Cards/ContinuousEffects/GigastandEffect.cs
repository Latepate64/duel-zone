using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

namespace Cards.ContinuousEffects
{
    class GigastandEffect : DestructionReplacementEffect
    {
        public GigastandEffect() : base()
        {
        }

        public GigastandEffect(GigastandEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            if (Controller.ChooseToTakeAction(ToString()))
            {
                game.AddReflexiveTriggeredAbility(new TriggeredAbilities.ReflexiveTriggeredAbility(new OneShotEffects.DiscardCardFromYourHandEffect(), Source));
                return new CardMovedEvent(gameEvent as ICardMovedEvent)
                {
                    Destination = ZoneType.Hand
                };
            }
            else
            {
                return gameEvent;
            }
        }

        public override IContinuousEffect Copy()
        {
            return new GigastandEffect(this);
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, you may return it to your hand instead. If you do, discard a card from your hand.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return IsSourceOfAbility(card, game);
        }
    }
}
