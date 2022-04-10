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
            return IsSourceOfAbility(card, game);
        }

        public override bool Apply(IGame game, IPlayer player, ICard creature)
        {
            game.Move(Common.ZoneType.SpellStack, Common.ZoneType.ManaZone, creature);
            return true;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisSpellHasChargerEffect(this);
        }

        public override bool Replaceable(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is ICardMovedEvent e && e.Source == Common.ZoneType.SpellStack && e.Destination == Common.ZoneType.Graveyard && e.CardInSourceZone == GetSourceCard(game).Id;
        }

        public override string ToString()
        {
            return "Charger";
        }
    }
}
