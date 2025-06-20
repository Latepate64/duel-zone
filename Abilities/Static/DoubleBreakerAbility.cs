using ContinuousEffects;
using Engine.Abilities;

namespace Abilities.Static;

public class DoubleBreakerAbility : StaticAbility
{
    public DoubleBreakerAbility() : base(new DoubleBreakerEffect())
    {
    }
}
