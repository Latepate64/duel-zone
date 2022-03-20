using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class CardMovingAreaOfEffect : OneShotAreaOfEffect
    {
        public ZoneType SourceZone { get; }
        public ZoneType DestinationZone { get; }

        public CardMovingAreaOfEffect(CardMovingAreaOfEffect effect) : base(effect)
        {
            SourceZone = effect.SourceZone;
            DestinationZone = effect.DestinationZone;
        }

        public CardMovingAreaOfEffect(ZoneType source, ZoneType destination, ICardFilter filter) : base(filter)
        {
            SourceZone = source;
            DestinationZone = destination;
        }

        public override object Apply(IGame game, IAbility source)
        {
            var cards = GetAffectedCards(game, source).ToArray();
            _ = game.Move(SourceZone, DestinationZone, cards);
            return cards.Any();
        }
    }
}
