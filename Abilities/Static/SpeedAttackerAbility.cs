using ContinuousEffects;
using Engine.Abilities;

namespace Abilities.Static;

public class SpeedAttackerAbility : StaticAbility
{
    public SpeedAttackerAbility() : base(new ThisCreatureHasSpeedAttackerEffect())
    {
    }
}
