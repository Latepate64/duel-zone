using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class MagmadragonOgristVhalEffect(int power = 3000) : PowerModifyingMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new MagmadragonOgristVhalEffect();
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each card in your hand.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return Controller.Hand.Size;
    }
}
