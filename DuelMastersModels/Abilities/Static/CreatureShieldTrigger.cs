using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class CreatureShieldTrigger : StaticAbilityForCreature
    {
        internal CreatureShieldTrigger(Creature creature) : base(creature, new Effects.ContinuousEffects.CreatureShieldTriggerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInYourHand)
        { }
    }
}
