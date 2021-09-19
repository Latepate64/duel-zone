using DuelMastersModels.Cards;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class CannotAttackPlayersEffect : CreatureContinuousEffect<Creature>
    {
        internal CannotAttackPlayersEffect(Periods.Period period, CardFilters.CreatureFilter<Creature> creatureFilter) : base(period, creatureFilter) { }
    }
}
