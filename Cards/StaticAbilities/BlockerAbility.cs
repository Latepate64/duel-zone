using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class BlockerAbility : StaticAbility
    {
        public BlockerAbility(params Engine.Condition[] conditions) : base(new BlockerEffect(new Engine.TargetFilter(), conditions))
        {
        }
    }
}
