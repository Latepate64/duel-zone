using Interfaces;

namespace OneShotEffects;

/// <summary>
/// For each creature you have in the battle zone, you may choose one of your
/// opponent's creatures in the battle zone and tap it.
/// </summary>
public sealed class ThunderNetEffect : OneShotEffect
{
    private readonly ICardFilter ownFilter;
    private readonly ICardFilter opponentFilter;

    public ThunderNetEffect(ICardFilter ownFilter, ICardFilter opponentFilter)
    {
        this.ownFilter = ownFilter;
        this.opponentFilter = opponentFilter;
    }

    public ThunderNetEffect(ThunderNetEffect effect) : base(effect)
    {
        ownFilter = effect.ownFilter.Copy();
        opponentFilter = effect.opponentFilter.Copy();
    }

    public override void Apply(IGame game)
    {
        var controller = Controller;
        var amount = game.BattleZone.GetNumberOfCreaturesControllerByPlayer(
            Applier, ownFilter);
        var creatures = controller.ChooseCards(
            game.BattleZone.GetOpponentsChoosableCreatures(
                Applier, opponentFilter, game),
            0, amount, ToString());
        controller.Tap(game, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new ThunderNetEffect(this);
    }
}
