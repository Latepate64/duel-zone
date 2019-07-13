using DuelMastersModels.CardFilters;
using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    public abstract class CreatureContinuousEffect : ContinuousEffect
    {
        public CreatureFilter CreatureFilter { get; private set; }

        protected CreatureContinuousEffect(Period period, CreatureFilter creatureFilter) : base(period)
        {
            CreatureFilter = creatureFilter;
        }
    }
}
