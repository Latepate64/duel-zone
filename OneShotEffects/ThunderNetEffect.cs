using Engine.Abilities;
using Interfaces;
using System.Linq;

namespace OneShotEffects;

public sealed class ThunderNetEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var controller = Controller;
        var amount = game.BattleZone.GetCreatures(controller.Id).Count(x => x.HasCivilization(Civilization.Water));
        var creatures = controller.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByPlayer(
            game, GetOpponent(game).Id), 0, amount, ToString());
        controller.Tap(game, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new ThunderNetEffect();
    }

    public override string ToString()
    {
        return "For each water creature you have in the battle zone, you may choose one of your opponent's creatures in the battle zone and tap it.";
    }
}
