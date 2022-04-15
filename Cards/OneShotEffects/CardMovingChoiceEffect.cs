using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    public abstract class CardMovingChoiceEffect : CardSelectionEffect
    {
        public ZoneType SourceZone { get; }
        public ZoneType DestinationZone { get; }

        public CardMovingChoiceEffect(int minimum, int maximum, bool controllerChooses, ZoneType source, ZoneType destination) : base(minimum, maximum, controllerChooses)
        {
            SourceZone = source;
            DestinationZone = destination;
        }

        public CardMovingChoiceEffect(CardMovingChoiceEffect effect) : base(effect)
        {
            SourceZone = effect.SourceZone;
            DestinationZone = effect.DestinationZone;
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.Move(SourceZone, DestinationZone, cards);
        }
    }
}
