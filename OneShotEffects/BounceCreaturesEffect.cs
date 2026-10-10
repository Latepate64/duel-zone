using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Return all creatures in the battle zone to their owners' hands.
/// </summary>
public sealed class BounceCreaturesEffect : BounceAreaOfEffect
{
    private readonly ICardFilter filter;

    public BounceCreaturesEffect(ICardFilter filter) : base()
    {
        this.filter = filter;
    }

    public BounceCreaturesEffect(BounceCreaturesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new BounceCreaturesEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(filter);
    }
}
