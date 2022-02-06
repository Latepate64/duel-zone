using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    public abstract class CardMovingChoiceEffect : CardSelectionEffect
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

        protected override void Apply(Game game, Ability source, IEnumerable<Engine.Card> cards)
        {
            game.Move(cards, SourceZone, DestinationZone);
        }
    }
}
