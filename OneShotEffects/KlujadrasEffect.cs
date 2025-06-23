using ContinuousEffects;
using Engine.Abilities;
using System.Linq;
using Interfaces;

namespace OneShotEffects;

public sealed class KlujadrasEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        foreach (var player in game.Players)
        {
            player.DrawCards(game.BattleZone.GetCreatures(player.Id).Count(
                x => x.GetAbilities<StaticAbility>().SelectMany(
                    x => x.ContinuousEffects).OfType<WaveStrikerEffect>().Any()), game, Ability);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new KlujadrasEffect();
    }

    public override string ToString()
    {
        return "Each player draws a card for each of his creatures in the battle zone that has \"wave striker.\"";
    }
}
