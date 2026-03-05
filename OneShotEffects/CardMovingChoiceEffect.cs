using Interfaces;

namespace OneShotEffects;

public abstract class CardMovingChoiceEffect<T> : CardSelectionEffect<T> where T : ICard
{
    public ZoneType SourceZone { get; }
    public ZoneType DestinationZone { get; }

    public CardMovingChoiceEffect(int minimum, int maximum, bool controllerChooses, ZoneType source,
        ZoneType destination) : base(minimum, maximum, controllerChooses)
    {
        SourceZone = source;
        DestinationZone = destination;
    }

    public CardMovingChoiceEffect(CardMovingChoiceEffect<T> effect) : base(effect)
    {
        SourceZone = effect.SourceZone;
        DestinationZone = effect.DestinationZone;
    }

    protected override void Apply(IGame game, IAbility source, params T[] cards)
    {
        game.Move(Ability, SourceZone, DestinationZone, cards);
    }
}
