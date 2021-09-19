using DuelMastersModels.CardFilters;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class SpeedAttackerEffect : CreatureContinuousEffect<Creature>
    {
        internal SpeedAttackerEffect(Period period, CreatureFilter<Creature> creatureFilter) : base(period, creatureFilter) { }
    }
}