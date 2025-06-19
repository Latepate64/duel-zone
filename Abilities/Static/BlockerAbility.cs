using Effects.Continuous;
using Engine.Abilities;

namespace Abilities.Static;

public class BlockerAbility : StaticAbility
{
    public BlockerAbility() : base(new ThisCreatureHasBlockerEffect())
    {
    }
}