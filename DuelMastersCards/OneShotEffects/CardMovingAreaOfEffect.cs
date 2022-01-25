using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class CardMovingAreaOfEffect : OneShotEffect
    {
        public ZoneType SourceZone { get; }
        public ZoneType DestinationZone { get; }
        public CardFilter Filter { get; }

        public CardMovingAreaOfEffect(CardMovingAreaOfEffect effect)
        {
            SourceZone = effect.SourceZone;
            DestinationZone = effect.DestinationZone;
            Filter = effect.Filter;
        }

        public CardMovingAreaOfEffect(ZoneType source, ZoneType destination, CardFilter filter)
        {
            SourceZone = source;
            DestinationZone = destination;
            Filter = filter;
        }

        public override void Apply(Game game, Ability source)
        {
            _ = game.Move(game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(source.Owner))), SourceZone, DestinationZone);
        }

        public override OneShotEffect Copy()
        {
            return new CardMovingAreaOfEffect(this);
        }
    }
}
