using DuelMastersModels.CardFilters;
using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    public class AttacksIfAbleEffect : CreatureContinuousEffect
    {
        public AttacksIfAbleEffect(Period period, CreatureFilter creatureFilter) : base(period, creatureFilter) { }
    }
}