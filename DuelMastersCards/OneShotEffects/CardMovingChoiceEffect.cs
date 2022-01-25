using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;
using System.Collections.Generic;

namespace DuelMastersCards.OneShotEffects
{
    class CardMovingChoiceEffect : CardSelectionEffect
    {
        public ZoneType SourceZone { get; }
        public ZoneType DestinationZone { get; }

        public CardMovingChoiceEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses, ZoneType source, ZoneType destination) : base(filter, minimum, maximum, controllerChooses)
        {
            SourceZone = source;
            DestinationZone = destination;
        }

        public CardMovingChoiceEffect(CardMovingChoiceEffect effect) : base(effect)
        {
            SourceZone = effect.SourceZone;
            DestinationZone = effect.DestinationZone;
        }

        public override OneShotEffect Copy()
        {
            return new CardMovingChoiceEffect(this);
        }

        protected override void Apply(Game game, Ability source, IEnumerable<Card> cards)
        {
            game.Move(cards, SourceZone, DestinationZone);
        }
    }
}
