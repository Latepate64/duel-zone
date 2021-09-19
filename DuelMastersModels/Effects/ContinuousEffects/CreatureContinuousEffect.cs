using DuelMastersModels.CardFilters;
using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal abstract class CreatureContinuousEffect<TCreature> : ContinuousEffect where TCreature : Cards.Creature
    {
        internal CreatureFilter<TCreature> CreatureFilter { get; private set; }

        protected CreatureContinuousEffect(Period period, CreatureFilter<TCreature> creatureFilter) : base(period)
        {
            CreatureFilter = creatureFilter;
        }
    }
}
