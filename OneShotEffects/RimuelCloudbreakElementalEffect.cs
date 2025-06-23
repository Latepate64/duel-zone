using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class RimuelCloudbreakElementalEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var controller = Controller;
        var amount = controller.ManaZone.UntappedCards.Count(x => x.HasCivilization(Civilization.Light));
        var creatures = controller.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByPlayer(
            game, GetOpponent(game).Id), amount, amount, ToString());
        controller.Tap(game, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new RimuelCloudbreakElementalEffect();
    }

    public override string ToString()
    {
        return "Tap one of your opponent's creatures in the battle zone for each untapped light card in your mana zone.";
    }
}
