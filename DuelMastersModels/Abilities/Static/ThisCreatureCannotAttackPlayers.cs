﻿using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.Static
{
    internal class ThisCreatureCannotAttackPlayers : StaticAbilityForCreature
    {
        internal ThisCreatureCannotAttackPlayers(Creature creature) : base(creature, new Effects.ContinuousEffects.CannotAttackPlayersEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetCreatureFilter(creature)), EffectActivityConditionForCreature.WhileThisCreatureIsInTheBattleZone)
        { }
    }
}
