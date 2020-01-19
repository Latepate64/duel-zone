using DuelMastersModels.Cards;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class PowerEffect : CreatureContinuousEffect<IBattleZoneCreature>
    {
        internal int Power { get; private set; }

        internal PowerEffect(Periods.Period period, CardFilters.CreatureFilter<IBattleZoneCreature> creatureFilter, int power) : base(period, creatureFilter) { Power = power; }
    }
}
