using DuelMastersModels.Cards;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class CannotAttackPlayersEffect : CreatureContinuousEffect<IBattleZoneCreature>
    {
        internal CannotAttackPlayersEffect(Periods.Period period, CardFilters.CreatureFilter<IBattleZoneCreature> creatureFilter) : base(period, creatureFilter) { }
    }
}
