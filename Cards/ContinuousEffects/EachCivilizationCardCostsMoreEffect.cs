﻿using Common;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class EachCivilizationCardCostsMoreEffect : CostModifyingEffect
    {
        private readonly Civilization _civilization;

        public EachCivilizationCardCostsMoreEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public EachCivilizationCardCostsMoreEffect(Civilization civilization, int increase) : base(increase, new CardFilters.CivilizationFilter(civilization), new Durations.Indefinite())
        {
            _civilization = civilization;
        }

        public override ContinuousEffect Copy()
        {
            return new EachCivilizationCardCostsMoreEffect(this);
        }

        public override string ToString()
        {
            return $"Each {_civilization} creature costs {CostChange} more to summon, and each {_civilization} spell costs {CostChange} more to cast.";
        }
    }
}
