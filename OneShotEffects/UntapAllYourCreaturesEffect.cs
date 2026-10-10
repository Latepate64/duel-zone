using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Untap all your creatures.
/// </summary>
public sealed class UntapAllYourCreaturesEffect : UntapAreaOfEffect
{
    private readonly ICardFilter filter;

    public UntapAllYourCreaturesEffect(ICardFilter filter) : base()
    {
        this.filter = filter;
    }

    public UntapAllYourCreaturesEffect(
        UntapAllYourCreaturesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new UntapAllYourCreaturesEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControllerByPlayer(Applier);
    }
}
