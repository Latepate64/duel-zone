using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Tap one of your opponent's creatures in the battle zone for each untapped light card in your mana zone.
/// </summary>
public sealed class RimuelCloudbreakElementalEffect : OneShotEffect
{
    private readonly ICardFilter filter;

    public RimuelCloudbreakElementalEffect(ICardFilter filter)
    {
        this.filter = filter;
    }

    public RimuelCloudbreakElementalEffect(
        RimuelCloudbreakElementalEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        var controller = Controller;
        var amount = controller.ManaZone.UntappedCards.Count(
            x => x.HasCivilization(Civilization.Light));
        var creatures = controller.ChooseCards(
            game.BattleZone.GetOpponentsChoosableCreatures(
                Applier, filter, game),
            amount, amount, ToString());
        controller.Tap(game, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new RimuelCloudbreakElementalEffect(this);
    }
}
