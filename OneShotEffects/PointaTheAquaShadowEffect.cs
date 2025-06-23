using Interfaces;

namespace OneShotEffects;

public sealed class PointaTheAquaShadowEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var controller = Controller;
        controller.LookAtOneOfOpponentsShields(game, Ability);
        game.GetOpponent(controller).DiscardAtRandom(game, 1, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new PointaTheAquaShadowEffect();
    }

    public override string ToString()
    {
        return "Look at one of your opponent's shields. Then your opponent discards a card at random from his hand.";
    }
}
