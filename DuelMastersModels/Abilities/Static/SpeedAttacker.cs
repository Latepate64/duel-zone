using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class SpeedAttacker : StaticAbilityForCreature
    {
        internal SpeedAttacker(Creature creature) : base(new Effects.ContinuousEffects.SpeedAttackerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInTheBattleZone, creature)
        { }

        public override Ability Copy()
        {
            throw new System.NotImplementedException();
        }
    }

    internal class DoubleBreaker : StaticAbility
    {
        internal DoubleBreaker(Creature creature) : base(null, creature) { } //TODO: Provide effect

        public override Ability Copy()
        {
            throw new System.NotImplementedException();
        }
    }
}

