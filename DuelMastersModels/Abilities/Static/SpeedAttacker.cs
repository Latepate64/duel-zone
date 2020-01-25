using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class SpeedAttacker : StaticAbilityForCreature
    {
        internal SpeedAttacker(IBattleZoneCreature creature) : base(creature, new Effects.ContinuousEffects.SpeedAttackerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter<IBattleZoneCreature>(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInTheBattleZone)
        { }
    }
}

