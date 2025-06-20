using ContinuousEffects;
using Engine.Abilities;

namespace Abilities.Static;

public class ThisCreatureCanAttackUntappedCreaturesAbility : StaticAbility
{
    public ThisCreatureCanAttackUntappedCreaturesAbility() : base(new ThisCreatureCanAttackUntappedCreaturesEffect())
    {
    }
}
