using Engine.Abilities;
using Interfaces;

namespace Cards.DM10;

public sealed class GalekTheShadowWarriorEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var player = Controller;
        player.DestroyOpponentsBlocker(game, Ability);
        game.GetOpponent(player).DiscardAtRandom(game, 1, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new GalekTheShadowWarriorEffect();
    }

    public override string ToString()
    {
        return "Destroy one of your opponent's creatures that has \"blocker.\" Then your opponent discards a card at random from his hand.";
    }
}
