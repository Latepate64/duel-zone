using Engine;
using Engine.GameEvents;
using System.Collections.Generic;

namespace Cards.ContinuousEffects
{
    class WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect : WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect
    {
        public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect() : base()
        {
        }

        public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(this);
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, return it to your hand instead.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return IsSourceOfAbility(card);
        }

        protected override List<ICard> GetAffectedCards(IGame game)
        {
            return new List<ICard> { Source };
        }
    }

    abstract class WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect : DestructionReplacementEffect
    {
        protected WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect effect) : base(effect)
        {
        }

        protected WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect() : base()
        {
        }

        protected abstract List<ICard> GetAffectedCards(IGame game);

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                Destination = ZoneType.Hand
            };
        }
    }
}