using Interfaces;

namespace OneShotEffects;

public sealed class ManaRecoveryAreaOfEffect : CardMovingAreaOfEffect
{
    private readonly ICardFilter filter;
    private readonly SelectionRange selectionRange;

    public ManaRecoveryAreaOfEffect(ICardFilter filter, SelectionRange selectionRange) : base(ZoneType.ManaZone, ZoneType.Hand, filter, selectionRange, excludeSource: false)
    {
        this.filter = filter;
        this.selectionRange = selectionRange;
    }

    private ManaRecoveryAreaOfEffect(ManaRecoveryAreaOfEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        selectionRange = effect.selectionRange;
    }

    public override IOneShotEffect Copy()
    {
        return new ManaRecoveryAreaOfEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        throw new NotImplementedException();
    }
}
