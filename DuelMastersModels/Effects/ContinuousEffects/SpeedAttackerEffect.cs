using DuelMastersModels.CardFilters;
using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    public class SpeedAttackerEffect : CreatureContinuousEffect
    {
        public SpeedAttackerEffect(Period period, CreatureFilter creatureFilter) : base(period, creatureFilter) { }
    }
}