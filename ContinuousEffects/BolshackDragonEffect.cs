using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class BolshackDragonEffect(int power = 1000) : PowerAttackerMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new BolshackDragonEffect();
    }

    public override string ToString()
    {
        return $"While attacking, this creature gets +{Power} power for each fire card in your graveyard.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return Controller.Graveyard.GetCardCount(Civilization.Fire);
    }
}
