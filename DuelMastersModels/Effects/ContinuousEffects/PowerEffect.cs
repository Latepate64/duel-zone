using DuelMastersModels.Cards;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class PowerEffect : CreatureContinuousEffect<Creature>
    {
        internal int Power { get; private set; }

        internal PowerEffect(Periods.Period period, CardFilters.CreatureFilter<Creature> creatureFilter, int power) : base(period, creatureFilter) { Power = power; }
    }
}
