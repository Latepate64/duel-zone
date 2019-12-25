using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.Static
{
    public class ThisCreatureAttacksEachTurnIfAble : StaticAbilityForCreature
    {
        public ThisCreatureAttacksEachTurnIfAble(Creature creature) : base(new Effects.ContinuousEffects.AttacksIfAbleEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter(creature)), StaticAbilityForCreatureActivityCondition.WhileThisCreatureIsInTheBattleZone)
        { }
    }
}
