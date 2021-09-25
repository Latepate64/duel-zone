using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class CreatureShieldTrigger : StaticAbilityForCreature
    {
        internal CreatureShieldTrigger(Creature creature, System.Guid source) : base(new Effects.ContinuousEffects.CreatureShieldTriggerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInYourHand, source)
        { }

        public override Ability Copy()
        {
            throw new System.NotImplementedException();
        }
    }
}
