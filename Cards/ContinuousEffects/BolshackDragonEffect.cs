﻿using Cards.CardFilters;
using Engine;
using Engine.ContinuousEffects;
using Engine.Durations;
using System.Linq;

namespace Cards.ContinuousEffects
{
    public class BolshackDragonEffect : PowerAttackerEffect
    {
        public CardFilter MultiplierFilter { get; }

        public BolshackDragonEffect(CardFilter multiplierFilter) : base(0)
        {
            MultiplierFilter = multiplierFilter;
        }

        public BolshackDragonEffect(BolshackDragonEffect effect) : base(effect)
        {
            MultiplierFilter = effect.MultiplierFilter.Copy();
        }

        public override int GetPower(Game game, Player player)
        {
            //this creature gets +1000 power for each fire card in your graveyard.
            return player.Graveyard.Cards.Where(x => MultiplierFilter.Applies(x, game, player)).Count() * 1000;
        }
    }
}
