using DuelMastersModels.CardFilters;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.Periods;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    internal class AttacksIfAbleEffect : CreatureContinuousEffect<IBattleZoneCreature>
    {
        internal AttacksIfAbleEffect(Period period, CreatureFilter<IBattleZoneCreature> creatureFilter) : base(period, creatureFilter) { }
    }
}