namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class SpellShieldTriggerEffect : SpellContinuousEffect
    {
        internal SpellShieldTriggerEffect(Periods.Period period, CardFilters.SpellFilter spellFilter) : base(period, spellFilter) { }
    }
}
