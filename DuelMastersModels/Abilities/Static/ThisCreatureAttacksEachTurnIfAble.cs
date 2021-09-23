using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class ThisCreatureAttacksEachTurnIfAble : StaticAbilityForCreature
    {
        internal ThisCreatureAttacksEachTurnIfAble(Creature creature, Card source) : base(new Effects.ContinuousEffects.AttacksIfAbleEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInTheBattleZone, source)
        { }

        public override Ability Copy()
        {
            throw new System.NotImplementedException();
        }
    }
}
