namespace DuelMastersModels.Effects.ContinuousEffects
{
    public class SpellShieldTriggerEffect : SpellContinuousEffect
    {
        public SpellShieldTriggerEffect(Periods.Period period, CardFilters.SpellFilter spellFilter) : base(period, spellFilter) { }
    }
}
