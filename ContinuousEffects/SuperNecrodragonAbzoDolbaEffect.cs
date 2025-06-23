using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace ContinuousEffects;

public sealed class SuperNecrodragonAbzoDolbaEffect(int power = 2000) : PowerModifyingMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new SuperNecrodragonAbzoDolbaEffect();
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each creature in your graveyard.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return Controller.Graveyard.Creatures.Count();
    }
}
