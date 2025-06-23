using Engine.Abilities;
using Interfaces;
using System.Linq;

namespace OneShotEffects;

public sealed class StaticWarpEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var chosen = game.Players.Select(x => x.ChooseCard(game.BattleZone.GetCreatures(x.Id), ToString()));
        Controller.Tap(game, [.. game.BattleZone.Creatures.Where(x => !chosen.Contains(x))]);
    }

    public override IOneShotEffect Copy()
    {
        return new StaticWarpEffect();
    }

    public override string ToString()
    {
        return "Each player chooses one of his creatures in the battle zone. Tap the rest of the creatures in the battle zone.";
    }
}
