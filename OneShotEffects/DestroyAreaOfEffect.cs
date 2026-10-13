using Interfaces;

namespace OneShotEffects;

public sealed class DestroyAreaOfEffect : CardMovingAreaOfEffect
{
    public DestroyAreaOfEffect(ICardFilter filter, SelectionRange selectionRange, bool excludeSource) : base(ZoneType.BattleZone, ZoneType.Graveyard, filter, selectionRange, excludeSource)
    {
    }

    private DestroyAreaOfEffect(DestroyAreaOfEffect effect) : base(effect)
    {
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
