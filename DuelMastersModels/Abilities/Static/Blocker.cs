using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class Blocker : StaticAbilityForCreature
    {
        internal Blocker(IBattleZoneCreature creature) : base(new Effects.ContinuousEffects.BlockerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter<IBattleZoneCreature>(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInTheBattleZone)
        { }
    }
}
