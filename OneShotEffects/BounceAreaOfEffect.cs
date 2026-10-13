using Interfaces;

namespace OneShotEffects;

public sealed class BounceAreaOfEffect : CardMovingAreaOfEffect
{
    public BounceAreaOfEffect(ICardFilter filter, SelectionRange selectionRange, bool excludeSource) : base(ZoneType.BattleZone, ZoneType.Hand, filter, selectionRange, excludeSource)
    {
    }

    private BounceAreaOfEffect(BounceAreaOfEffect effect) : base(effect)
    {
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
