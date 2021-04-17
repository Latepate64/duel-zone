using DuelMastersModels.Cards;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class BlockerEffect : CreatureContinuousEffect<IBattleZoneCreature>
    {
        internal BlockerEffect(Periods.Period period, CardFilters.CreatureFilter<IBattleZoneCreature> creatureFilter) : base(period, creatureFilter) { }
    }
}
