using Interfaces;

namespace OneShotEffects;

public abstract class ClonedEffect : OneShotEffect
{
    protected readonly string _name;

    protected ClonedEffect(string name)
    {
        _name = name;
    }

    protected ClonedEffect(ClonedEffect effect)
    {
        _name = effect._name;
    }

    protected int GetAmount(IGame game)
    {
        return 1 + game.Players.SelectMany(x => x.Graveyard.CardsWithName(_name)).Count();
    }
}
