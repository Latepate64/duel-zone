using DuelMastersModels.Cards;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class BlockerEffect : CreatureContinuousEffect<Creature>
    {
        internal BlockerEffect(Periods.Period period, CardFilters.CreatureFilter<Creature> creatureFilter) : base(period, creatureFilter) { }
    }
}
