using DuelMastersModels.Effects.ContinuousEffects;

namespace DuelMastersModels.Abilities.Static
{
    public enum StaticAbilityForSpellActivityCondition
    {
        WhileThisSpellIsInYourHand,
    }

    public abstract class StaticAbilityForSpell : StaticAbility
    {
        public StaticAbilityForSpellActivityCondition ActivityCondition { get; private set; }

        protected StaticAbilityForSpell(ContinuousEffect continuousEffect, StaticAbilityForSpellActivityCondition activityCondition) : base(continuousEffect)
        {
        }
    }
}
