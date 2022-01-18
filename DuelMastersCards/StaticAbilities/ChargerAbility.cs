﻿using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class ChargerAbility : StaticAbility
    {
        public ChargerAbility()
        {
            ContinuousEffects.Add(new ChargerEffect(new TargetFilter(), new Indefinite()));
        }
    }
}
