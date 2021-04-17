using DuelMastersModels.CardFilters;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class SpeedAttackerEffect : CreatureContinuousEffect<IBattleZoneCreature>
    {
        internal SpeedAttackerEffect(Period period, CreatureFilter<IBattleZoneCreature> creatureFilter) : base(period, creatureFilter) { }
    }
}