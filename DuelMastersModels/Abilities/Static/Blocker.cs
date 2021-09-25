using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class Blocker : StaticAbilityForCreature
    {
        internal Blocker(Creature creature, System.Guid source) : base(new Effects.ContinuousEffects.BlockerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInTheBattleZone, source)
        { }

        public override Ability Copy()
        {
            throw new System.NotImplementedException();
        }
    }
}
