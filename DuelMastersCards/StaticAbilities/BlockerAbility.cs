using Cards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

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
