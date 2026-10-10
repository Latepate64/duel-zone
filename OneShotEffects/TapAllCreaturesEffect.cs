using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Tap all creatures in the battle zone.
/// </summary>
public sealed class TapAllCreaturesEffect : TapAreaOfEffect
{
    private readonly ICardFilter filter;

    public TapAllCreaturesEffect(ICardFilter filter) : base()
    {
        this.filter = filter;
    }

    public TapAllCreaturesEffect(TapAllCreaturesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new TapAllCreaturesEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(filter);
    }
}
