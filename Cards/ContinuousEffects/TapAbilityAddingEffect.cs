﻿using Common;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class TapAbilityAddingEffect : AbilityAddingEffect
    {
        private readonly Civilization _civilization;

        public TapAbilityAddingEffect(TapAbilityAddingEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public TapAbilityAddingEffect(Civilization civilization, IOneShotEffect effect) : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(civilization), new Durations.Indefinite(), new TapAbility(effect))
        {
            _civilization = civilization;
        }

        public override IContinuousEffect Copy()
        {
            return new TapAbilityAddingEffect(this);
        }

        public override string ToString()
        {
            return $"Each of your {_civilization} creatures may tap instead of attacking to use this creature's ability. : {AbilitiesAsText}";
        }
    }
}