using Interfaces;

namespace OneShotEffects;

/// <summary>
/// For each creature you have in the battle zone, you may choose one of your
/// opponent's creatures in the battle zone and return it to his hand.
/// </summary>
public sealed class HydroHurricaneSecondEffect : OneShotEffect
{
    private readonly ICardFilter ownFilter;
    private readonly ICardFilter opponentFilter;

    public HydroHurricaneSecondEffect(
        ICardFilter ownFilter, ICardFilter opponentFilter)
    {
        this.ownFilter = ownFilter;
        this.opponentFilter = opponentFilter;
    }

    public HydroHurricaneSecondEffect(
        HydroHurricaneSecondEffect effect) : base(effect)
    {
        ownFilter = effect.ownFilter.Copy();
        opponentFilter = effect.opponentFilter.Copy();
    }

    public override void Apply(IGame game)
    {
        var controller = Controller;
        var amount = game.BattleZone.GetNumberOfCreaturesControllerByPlayer(
            Applier, ownFilter);
        var cards = game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, opponentFilter, game);
        var creatures = controller.ChooseCards(
            cards, 0, amount, ToString()).ToArray();
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, creatures);
    }

    public override IOneShotEffect Copy()
    {
        return new HydroHurricaneSecondEffect(this);
    }
}
