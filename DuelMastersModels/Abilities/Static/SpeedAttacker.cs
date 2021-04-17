using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class SpeedAttacker : StaticAbilityForCreature
    {
        internal SpeedAttacker(IBattleZoneCreature creature) : base(new Effects.ContinuousEffects.SpeedAttackerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter<IBattleZoneCreature>(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInTheBattleZone)
        { }
    }
}

