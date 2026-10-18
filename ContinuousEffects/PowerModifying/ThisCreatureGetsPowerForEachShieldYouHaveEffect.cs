using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

public sealed class ThisCreatureGetsPowerForEachShieldYouHaveEffect : PowerModifyingMultiplierEffect
{
    public ThisCreatureGetsPowerForEachShieldYouHaveEffect(int power) : base(power)
    {
    }

    public ThisCreatureGetsPowerForEachShieldYouHaveEffect(
        ThisCreatureGetsPowerForEachShieldYouHaveEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerForEachShieldYouHaveEffect(this);
    }

    protected override int GetMultiplier(IGame game)
    {
        return Controller.ShieldZone.Size;
    }
}
