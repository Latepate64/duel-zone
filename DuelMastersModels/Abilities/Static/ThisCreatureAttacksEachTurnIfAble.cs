using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class ThisCreatureAttacksEachTurnIfAble : StaticAbilityForCreature
    {
        internal ThisCreatureAttacksEachTurnIfAble(IBattleZoneCreature creature) : base(new Effects.ContinuousEffects.AttacksIfAbleEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter<IBattleZoneCreature>(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInTheBattleZone)
        { }
    }
}
