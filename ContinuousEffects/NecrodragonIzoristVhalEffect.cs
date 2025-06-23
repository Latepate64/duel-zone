using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class NecrodragonIzoristVhalEffect(int power = 2000) : PowerModifyingMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new NecrodragonIzoristVhalEffect();
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each darkness creature in your graveyard.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return Controller.Graveyard.GetCreatureCount(Civilization.Darkness);
    }
}
