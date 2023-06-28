using Engine;
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

        public CardMovingAreaOfEffect(ZoneType source, ZoneType destination) : base()
        {
            SourceZone = source;
            DestinationZone = destination;
        }

        public override void Apply()
        {
            var cards = GetAffectedCards(Ability).ToArray();
            _ = Game.Move(Ability, SourceZone, DestinationZone, cards);
        }
    }
}
