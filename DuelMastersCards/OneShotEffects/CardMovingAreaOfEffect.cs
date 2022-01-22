using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class CardMovingAreaOfEffect : CardMovingEffect
    {
        public CardMovingAreaOfEffect(CardMovingEffect effect) : base(effect)
        {
        }

        public CardMovingAreaOfEffect(ZoneType source, ZoneType destination, CardFilter filter) : base(source, destination, filter)
        {
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
