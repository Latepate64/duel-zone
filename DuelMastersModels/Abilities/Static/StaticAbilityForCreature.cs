using DuelMastersModels.Effects.ContinuousEffects;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    /// <summary>
    /// Static abilities create continuous effects, some of which are prevention effects or replacement effects. These effects are active as long as the creature with the ability remains on the battle zone and has the ability, or as long as the creature with the ability remains in the appropriate zone.
    /// </summary>
    public enum EffectActivityConditionForCreature
    {
        /// <summary>
        /// Effects are active regardless where the creature with the ability is located in.
        /// </summary>
        Anywhere,

        /// <summary>
        /// Effects are active while the creature with the ability is in the battle zone.
        /// </summary>
        WhileThisCreatureIsInTheBattleZone,

        /// <summary>
        /// Effects are active while the creature with the ability is in its owner's hand.
        /// </summary>
        WhileThisCreatureIsInYourHand,
    }

    /// <summary>
    /// Static ability only creatures can have.
    /// </summary>
    internal abstract class StaticAbilityForCreature : StaticAbility
    {
        /// <summary>
        /// Activity condition for the effects created by the ability.
        /// </summary>
        internal EffectActivityConditionForCreature EffectActivityCondition { get; private set; }

        protected StaticAbilityForCreature(ContinuousEffect continuousEffect, EffectActivityConditionForCreature effectActivityCondition, Cards.Card source) : base(continuousEffect, source)
        {
            EffectActivityCondition = effectActivityCondition;
        }
    }
}
