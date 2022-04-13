using Common;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

namespace Cards.ContinuousEffects
{
    abstract class WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : DestructionReplacementEffect
    {
        protected WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect() : base()
        {
        }

        protected WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                Destination = ZoneType.ManaZone
            };
        }
    }

    class WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect
    {
        public WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect();
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, put it into your mana zone instead.";
        }

        protected override bool Applies(Engine.ICard card, IGame game)
        {
            return IsSourceOfAbility(card, game);
        }
    }
}