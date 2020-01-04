using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.Static
{
    internal class ThisCreatureAttacksEachTurnIfAble : StaticAbilityForCreature
    {
        internal ThisCreatureAttacksEachTurnIfAble(Creature creature) : base(creature, new Effects.ContinuousEffects.AttacksIfAbleEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInTheBattleZone)
        { }
    }
}
