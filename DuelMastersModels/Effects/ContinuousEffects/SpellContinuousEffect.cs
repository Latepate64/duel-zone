using DuelMastersModels.CardFilters;
using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    public abstract class SpellContinuousEffect : ContinuousEffect
    {
        public SpellFilter SpellFilter { get; private set; }

        protected SpellContinuousEffect(Period period, SpellFilter spellFilter) : base(period)
        {
            SpellFilter = spellFilter;
        }
    }
}
