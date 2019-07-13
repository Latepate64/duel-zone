namespace DuelMastersModels.Effects.ContinuousEffects
{
    public class BlockerEffect : CreatureContinuousEffect
    {
        public BlockerEffect(Periods.Period period, CardFilters.CreatureFilter creatureFilter) : base(period, creatureFilter) { }
    }
}
