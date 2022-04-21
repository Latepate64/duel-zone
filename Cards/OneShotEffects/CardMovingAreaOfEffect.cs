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

        public CardMovingAreaOfEffect(ZoneType source, ZoneType destination) : base()
        {
            SourceZone = source;
            DestinationZone = destination;
        }

        public override void Apply(IGame game)
        {
            var cards = GetAffectedCards(game, GetSourceAbility(game)).ToArray();
            _ = game.Move(GetSourceAbility(game), SourceZone, DestinationZone, cards);
        }
    }
}
