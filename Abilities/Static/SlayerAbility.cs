using ContinuousEffects;
using Engine.Abilities;

namespace Abilities.Static;

public class SlayerAbility : StaticAbility
{
    public SlayerAbility() : base(new ThisCreatureHasSlayerEffect())
    {
    }
}
