﻿using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.ContinuousEffects
{
    public class PowerModifyingMultiplierEffect : PowerModifyingEffect
    {
        public CardFilter MultiplierFilter { get; }

        public PowerModifyingMultiplierEffect(CardFilter multiplierFilter) : base(new List<CardFilter> { new AttackingCreatureFilter(), new TargetFilter() }, 0, new Indefinite())
        {
            MultiplierFilter = multiplierFilter;
        }

        public PowerModifyingMultiplierEffect(PowerModifyingMultiplierEffect effect) : base(effect)
        {
            MultiplierFilter = effect.MultiplierFilter.Copy();
        }

        public override int GetPower(Duel duel)
        {
            //this creature gets +1000 power for each fire card in your graveyard.
            return duel.GetPlayer(Controller).Graveyard.Cards.Where(x => MultiplierFilter.Applies(x, duel)).Count() * 1000;
        }
    }
}