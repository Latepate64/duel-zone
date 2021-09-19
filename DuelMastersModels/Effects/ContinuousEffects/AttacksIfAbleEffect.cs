using DuelMastersModels.CardFilters;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class AttacksIfAbleEffect : CreatureContinuousEffect<Creature>
    {
        internal AttacksIfAbleEffect(Period period, CreatureFilter<Creature> creatureFilter) : base(period, creatureFilter) { }
    }
}