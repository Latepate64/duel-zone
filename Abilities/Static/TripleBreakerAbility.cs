using ContinuousEffects;
using Engine.Abilities;

namespace Abilities.Static;

public class TripleBreakerAbility : StaticAbility
{
    public TripleBreakerAbility() : base(new TripleBreakerEffect())
    {
    }
}

