using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.Static
{
    public class SpeedAttacker : StaticAbilityForCreature
    {
        public SpeedAttacker(Creature creature) : base(new Effects.ContinuousEffects.SpeedAttackerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter(creature)), StaticAbilityForCreatureActivityCondition.WhileThisCreatureIsInTheBattleZone)
        { }
    }
}

