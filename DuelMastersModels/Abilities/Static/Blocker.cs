using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.Static
{
    internal class Blocker : StaticAbilityForCreature
    {
        internal Blocker(Creature creature) : base(creature, new Effects.ContinuousEffects.BlockerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInTheBattleZone)
        { }
    }
}
