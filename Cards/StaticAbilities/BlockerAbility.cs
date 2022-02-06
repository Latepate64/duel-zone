using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class BlockerAbility : StaticAbility
    {
        public BlockerAbility() : base()
        {
            ContinuousEffects.Add(new BlockerEffect());
        }
    }
}
