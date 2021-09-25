using DuelMastersModels.Effects.ContinuousEffects;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    /// <summary>
    /// Static abilities create continuous effects, some of which are prevention effects or replacement effects. These effects are active as long as the spell with the ability remains in the appropriate zone.
    /// </summary>
    public enum StaticAbilityForSpellActivityCondition
    {
        /// <summary>
        /// Effects are active while the spell with the ability is in its owner's hand.
        /// </summary>
        WhileThisSpellIsInYourHand,
    }

    /// <summary>
    /// Static ability only spells can have.
    /// </summary>
    internal abstract class StaticAbilityForSpell : StaticAbility
    {
        /// <summary>
        /// Activity condition for the effects created by the ability.
        /// </summary>
        internal StaticAbilityForSpellActivityCondition EffectActivityCondition { get; private set; }

        protected StaticAbilityForSpell(ContinuousEffect continuousEffect, StaticAbilityForSpellActivityCondition effectActivityCondition, System.Guid source) : base(continuousEffect, source)
        {
            EffectActivityCondition = effectActivityCondition;
        }
    }
}
