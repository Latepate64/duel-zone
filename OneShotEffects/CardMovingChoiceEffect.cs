using Interfaces;

namespace OneShotEffects;

public abstract class CardMovingChoiceEffect<T> : CardSelectionEffect<T> where T : ICard
{
    public ZoneType SourceZone { get; }
    public ZoneType DestinationZone { get; }
    protected readonly ICardFilter filter;

    public CardMovingChoiceEffect(
        int minimum,
        int maximum,
        bool controllerChooses,
        ICardFilter filter,
        ZoneType source,
        ZoneType destination) : base(minimum, maximum, controllerChooses)
    {
        this.filter = filter;
        SourceZone = source;
        DestinationZone = destination;
    }

    public CardMovingChoiceEffect(CardMovingChoiceEffect<T> effect) : base(effect)
    {
        filter = effect.filter.Copy();
        SourceZone = effect.SourceZone;
        DestinationZone = effect.DestinationZone;
    }

    protected override void Apply(IGame game, IAbility source, params T[] cards)
    {
        game.Move(Ability, SourceZone, DestinationZone, cards);
    }
}
