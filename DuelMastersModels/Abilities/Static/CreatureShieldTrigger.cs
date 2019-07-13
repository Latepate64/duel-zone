using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.Static
{
    public class CreatureShieldTrigger : StaticAbilityForCreature
    {
        public CreatureShieldTrigger(Creature creature) : base(new Effects.ContinuousEffects.CreatureShieldTriggerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter(creature)), StaticAbilityForCreatureActivityCondition.WhileThisCreatureIsInYourHand)
        { }
    }
}
