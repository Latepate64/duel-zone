using Engine.Abilities;
using Interfaces;

namespace Cards.DM08;

public class FuriousOnslaughtOneShotEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new FuriousOnslaughtContinuousEffect(
            [.. game.BattleZone.GetCreatures(Ability.Controller.Id, Race.Dragonoid)]));
    }

    public override IOneShotEffect Copy()
    {
        return new FuriousOnslaughtOneShotEffect();
    }

    public override string ToString()
    {
        return "Until the end of the turn, each of your Dragonoids in the battle zone is an Armored Dragon in addition to its other races, gets +4000 power, and has \"double breaker.\"";
    }
}
