using Interfaces;

namespace OneShotEffects;

public sealed class BounceAreaOfEffect : CardMovingAreaOfEffect
{
    private readonly ICardFilter filter;
    private readonly SelectionRange selectionRange;
    private readonly bool excludeSource;

    public BounceAreaOfEffect(ICardFilter filter, SelectionRange selectionRange, bool excludeSource) : base(ZoneType.BattleZone, ZoneType.Hand)
    {
        this.filter = filter;
        this.selectionRange = selectionRange;
        this.excludeSource = excludeSource;
    }

    private BounceAreaOfEffect(BounceAreaOfEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        selectionRange = effect.selectionRange;
        excludeSource = effect.excludeSource;
    }

    public override IOneShotEffect Copy()
    {
        return new BounceAreaOfEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        throw new NotImplementedException();
    }
}
