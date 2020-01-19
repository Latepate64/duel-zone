using DuelMastersModels.Cards;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class CreatureShieldTriggerEffect : CreatureContinuousEffect<IHandCreature>
    {
        internal CreatureShieldTriggerEffect(Periods.Period period, CardFilters.CreatureFilter<IHandCreature> creatureFilter) : base(period, creatureFilter) { }
    }
}
