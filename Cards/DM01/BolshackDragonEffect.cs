using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM01;

public class BolshackDragonEffect(int power = 1000) : PowerAttackerMultiplierEffect(power)
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
