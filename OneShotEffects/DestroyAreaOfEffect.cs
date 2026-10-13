using Interfaces;

namespace OneShotEffects;

public sealed class DestroyAreaOfEffect : CardMovingAreaOfEffect
{
    private readonly ICardFilter filter;
    private readonly SelectionRange selectionRange;
    private readonly bool excludeSource;

    public DestroyAreaOfEffect(ICardFilter filter, SelectionRange selectionRange, bool excludeSource) : base(ZoneType.BattleZone, ZoneType.Graveyard)
    {
        this.filter = filter;
        this.selectionRange = selectionRange;
        this.excludeSource = excludeSource;
    }

    private DestroyAreaOfEffect(DestroyAreaOfEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        selectionRange = effect.selectionRange;
        excludeSource = effect.excludeSource;
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyAreaOfEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        throw new NotImplementedException();
    }
}
