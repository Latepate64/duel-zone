using Interfaces;

namespace OneShotEffects;

public class CardMovingAreaOfEffect : OneShotAreaOfEffect
{
    public ZoneType SourceZone { get; }
    public ZoneType DestinationZone { get; }
    private readonly ICardFilter filter;
    private readonly SelectionRange selectionRange;
    private readonly bool excludeSource;

    public CardMovingAreaOfEffect(
        ZoneType source,
        ZoneType destination,
        ICardFilter filter,
        SelectionRange selectionRange,
        bool excludeSource) : base()
    {
        SourceZone = source;
        DestinationZone = destination;
        this.filter = filter;
        this.selectionRange = selectionRange;
        this.excludeSource = excludeSource;
    }

    protected CardMovingAreaOfEffect(CardMovingAreaOfEffect effect) : base(effect)
    {
        SourceZone = effect.SourceZone;
        DestinationZone = effect.DestinationZone;
        filter = effect.filter.Copy();
        selectionRange = effect.selectionRange;
        excludeSource = effect.excludeSource;
    }

    public override void Apply(IGame game)
    {
        var cards = GetAffectedCards(game, Ability).ToArray();
        _ = game.Move(Ability, SourceZone, DestinationZone, cards);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        throw new NotImplementedException();
    }

    public override IOneShotEffect Copy()
    {
        return new CardMovingAreaOfEffect(this);
    }
}
