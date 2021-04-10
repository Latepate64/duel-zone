using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class CreatureShieldTrigger : StaticAbilityForCreature
    {
        internal CreatureShieldTrigger(IHandCreature creature) : base(new Effects.ContinuousEffects.CreatureShieldTriggerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter<IHandCreature>(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInYourHand)
        { }
    }
}
