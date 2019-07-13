using DuelMastersModels.Effects.ContinuousEffects;

namespace DuelMastersModels.Abilities.Static
{
    public enum StaticAbilityForCreatureActivityCondition
    {
        Anywhere,
        WhileThisCreatureIsInTheBattleZone,
        WhileThisCreatureIsInYourHand,
    }

    public abstract class StaticAbilityForCreature : StaticAbility
    {
        public StaticAbilityForCreatureActivityCondition ActivityCondition { get; private set; }

        protected StaticAbilityForCreature(ContinuousEffect continuousEffect, StaticAbilityForCreatureActivityCondition activityCondition) : base(continuousEffect)
        {
        }
    }
}
