using Cards.CardFilters;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.StaticAbilities
{
    public class BlockerAbility : StaticAbility
    {
        public BlockerAbility() : base()
        {
            ContinuousEffects.Add(new BlockerEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
