using Interfaces;

namespace OneShotEffects;

public sealed class LookAtYourOpponentsHandEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        Controller.LookAtOpponentsHand(game);
    }

    public override IOneShotEffect Copy()
    {
        return new LookAtYourOpponentsHandEffect();
    }

    public override string ToString()
    {
        return "Look at your opponent's hand.";
    }
}
