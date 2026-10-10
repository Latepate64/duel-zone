using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Tap all your opponent's creatures in the battle zone.
/// </summary>
public sealed class TapOpponentsCreaturesEffect : TapAreaOfEffect
{
    private readonly ICardFilter filter;

    public TapOpponentsCreaturesEffect(ICardFilter filter) : base()
    {
        this.filter = filter;
    }

    public TapOpponentsCreaturesEffect(
        TapOpponentsCreaturesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new TapOpponentsCreaturesEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControllerByPlayer(
            Applier.Opponent, filter);
    }
}
