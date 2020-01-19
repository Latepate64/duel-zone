using DuelMastersModels.CardFilters;
using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal abstract class CreatureContinuousEffect<TZoneCreature> : ContinuousEffect where TZoneCreature : Cards.IZoneCreature
    {
        internal CreatureFilter<TZoneCreature> CreatureFilter { get; private set; }

        protected CreatureContinuousEffect(Period period, CreatureFilter<TZoneCreature> creatureFilter) : base(period)
        {
            CreatureFilter = creatureFilter;
        }
    }
}
