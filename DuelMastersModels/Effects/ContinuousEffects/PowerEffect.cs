namespace DuelMastersModels.Effects.ContinuousEffects
{
    public class PowerEffect : CreatureContinuousEffect
    {
        public int Power { get; private set; }

        public PowerEffect(Periods.Period period, CardFilters.CreatureFilter creatureFilter, int power) : base(period, creatureFilter) { Power = power; }
    }
}
