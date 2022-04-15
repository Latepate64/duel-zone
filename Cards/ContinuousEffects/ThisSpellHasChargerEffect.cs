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

        public bool Applies(Engine.ICard card, IGame game)
        {
            return IsSourceOfAbility(card, game);
        }

        public override IContinuousEffect Copy()
        {
            return new ThisSpellHasChargerEffect(this);
        }

        public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is ICardMovedEvent e && e.Source == ZoneType.SpellStack && e.Destination == ZoneType.Graveyard && e.CardInSourceZone == GetSourceCard(game).Id;
        }

        public override string ToString()
        {
            return "Charger";
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                Destination = ZoneType.ManaZone
            };
        }
    }
}
