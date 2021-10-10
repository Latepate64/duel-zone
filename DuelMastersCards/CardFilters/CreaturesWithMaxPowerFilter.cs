﻿using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    public class CreaturesWithMaxPowerFilter : CardFilter
    {
        public int Power { get; }

        public CreaturesWithMaxPowerFilter(int power)
        {
            Power = power;
        }

        public CreaturesWithMaxPowerFilter(CreaturesWithMaxPowerFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override bool Applies(Card card, Duel duel)
        {
            return card.CardType == CardType.Creature && duel.GetPower(card) <= Power;
        }

        public override CardFilter Copy()
        {
            return new CreaturesWithMaxPowerFilter(this);
        }
    }
}
