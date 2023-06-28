using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

namespace Cards.ContinuousEffects
{
    class ThisSpellHasChargerEffect : ReplacementEffect, IChargerEffect
    {
        public ThisSpellHasChargerEffect() : base()
        {
        }

        public ThisSpellHasChargerEffect(ThisSpellHasChargerEffect effect) : base(effect)
        {
        }

        public bool Applies(ICard card, IGame game)
        {
            return IsSourceOfAbility(card);
        }

        public override IContinuousEffect Copy()
        {
            return new ThisSpellHasChargerEffect(this);
        }

        public override bool CanBeApplied(IGameEvent gameEvent)
        {
            return gameEvent is ICardMovedEvent e && e.Source == ZoneType.SpellStack && e.Destination == ZoneType.Graveyard && e.CardInSourceZone == Source.Id;
        }

        public override string ToString()
        {
            return "Charger";
        }

        public override IGameEvent Apply(IGameEvent gameEvent)
        {
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                Destination = ZoneType.ManaZone
            };
        }
    }
}
