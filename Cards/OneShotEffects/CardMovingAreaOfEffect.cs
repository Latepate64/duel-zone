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

        public CardMovingAreaOfEffect(ZoneType source, ZoneType destination, CardFilter filter) : base(filter)
        {
            SourceZone = source;
            DestinationZone = destination;
        }

        public override void Apply(Game game, Ability source)
        {
            _ = game.Move(SourceZone, DestinationZone, GetAffectedCards(game, source).ToArray());
        }
    }
}
