using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Return any number of your creatures from the battle zone to your hand. Then
/// you may choose that many of your opponent's creatures in the battle zone and
/// return them to your opponent's hand.
/// </summary>
public sealed class ShockHurricaneEffect : OneShotEffect
{
    private readonly ICardFilter ownFilter;
    private readonly ICardFilter opponentFilter;

    public ShockHurricaneEffect(
        ICardFilter ownFilter, ICardFilter opponentFilter)
    {
        this.ownFilter = ownFilter;
        this.opponentFilter = opponentFilter;
    }

    public ShockHurricaneEffect(ShockHurricaneEffect effect) : base(effect)
    {
        ownFilter = effect.ownFilter.Copy();
        opponentFilter = effect.opponentFilter.Copy();
    }

    public override void Apply(IGame game)
    {
        var player = Controller;
        var ownCreatures = player.ChooseAnyNumberOfCards(
            game.BattleZone.GetCreaturesControlledByPlayer(
                Applier, ownFilter),
            ToString());
        var amount = ownCreatures.Count();
        game.Move(
            Ability, ZoneType.BattleZone, ZoneType.Hand, [.. ownCreatures]);
        var opponentsCreatures = game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, opponentFilter, game);
        var choosableAmount = opponentsCreatures.Count();
        if (amount > 0 && amount <= choosableAmount)
        {
            if (Controller.ChooseToTakeAction(
                $"You may choose {amount} of your opponent's creatures in the battle zone and return them to your opponent's hand."))
            {
                var creatures = player.ChooseCards(
                    opponentsCreatures, amount, amount, ToString());
                game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand,
                    [.. creatures]);
            }
        }
    }

    public override IOneShotEffect Copy()
    {
        return new ShockHurricaneEffect(this);
    }
}
