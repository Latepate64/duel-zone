using Engine.Abilities;
using Interfaces;

namespace Cards.DM10;

public class YouLoseTheGameAtTheEndOfTheExtraTurnEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        game.Lose(Controller);
    }

    public override IOneShotEffect Copy()
    {
        return new YouLoseTheGameAtTheEndOfTheExtraTurnEffect();
    }

    public override string ToString()
    {
        return "You lose the game.";
    }
}
