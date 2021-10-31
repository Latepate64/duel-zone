using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using System.Collections.Generic;

namespace DuelMastersCards.StaticAbilities
{
    public class PowerAttackerAbility : StaticAbility
    {
        public PowerAttackerAbility(int power)
        {
            ContinuousEffects.Add(new PowerModifyingEffect(new List<CardFilter> { new AttackingCreatureFilter(), new TargetFilter() }, power, new Indefinite()));
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
