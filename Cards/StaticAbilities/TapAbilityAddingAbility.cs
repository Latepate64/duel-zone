﻿using Common;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.StaticAbilities
{
    class TapAbilityAddingAbility : StaticAbility
    {
        public TapAbilityAddingAbility(Civilization civilization, IOneShotEffect effect) : base(new TapAbilityAddingEffect(civilization, effect))
        {
        }
    }

    class TapAbilityAddingEffect : AbilityAddingEffect
    {
        private readonly Civilization _civilization;

        public TapAbilityAddingEffect(TapAbilityAddingEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public TapAbilityAddingEffect(Civilization civilization, IOneShotEffect effect) : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(civilization), new Engine.Durations.Indefinite(), new TapAbility(effect))
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