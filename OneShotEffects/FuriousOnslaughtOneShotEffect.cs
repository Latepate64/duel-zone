using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Until the end of the turn, each of your creatures in the battle zone is an
/// Armored Dragon in addition to its other races, gets +4000 power, and has
/// "double breaker."
/// </summary>
public sealed class FuriousOnslaughtOneShotEffect : OneShotEffect
{
    private readonly ICardFilter filter;

    public FuriousOnslaughtOneShotEffect(ICardFilter filter)
    {
        this.filter = filter;
    }

    public FuriousOnslaughtOneShotEffect(
        FuriousOnslaughtOneShotEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new FuriousOnslaughtContinuousEffect(
            [.. game.BattleZone.GetCreaturesControllerByPlayer(
                Applier, filter)]));
    }

    public override IOneShotEffect Copy()
    {
        return new FuriousOnslaughtOneShotEffect(this);
    }
}
