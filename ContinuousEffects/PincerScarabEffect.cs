using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class PincerScarabEffect(int power = 2000) : PowerModifyingMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new PincerScarabEffect(Power);
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each card in your opponent's hand.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.GetPlayer(game.GetOpponent(Controller.Id)).Hand.Size;
    }
}
