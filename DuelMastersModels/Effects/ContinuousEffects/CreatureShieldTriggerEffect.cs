using DuelMastersModels.Cards;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class CreatureShieldTriggerEffect : CreatureContinuousEffect<Creature>
    {
        internal CreatureShieldTriggerEffect(Periods.Period period, CardFilters.CreatureFilter<Creature> creatureFilter) : base(period, creatureFilter) { }
    }
}
