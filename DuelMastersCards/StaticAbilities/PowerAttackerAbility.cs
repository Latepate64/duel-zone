﻿using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class PowerAttackerAbility : StaticAbility
    {
        public PowerAttackerAbility(int power)
        {
            ContinuousEffects.Add(new PowerAttackerEffect(new TargetFilter(), new Indefinite(), power));
        }

        public PowerAttackerAbility(PowerAttackerAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new PowerAttackerAbility(this);
        }
    }
}
