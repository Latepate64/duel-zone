namespace DuelMastersModels.Effects.ContinuousEffects
{
    public class CannotAttackPlayersEffect : CreatureContinuousEffect
    {
        public CannotAttackPlayersEffect(Periods.Period period, CardFilters.CreatureFilter creatureFilter) : base(period, creatureFilter) { }
    }
}
