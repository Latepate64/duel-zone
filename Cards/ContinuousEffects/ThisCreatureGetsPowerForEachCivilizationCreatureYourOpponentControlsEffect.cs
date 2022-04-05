﻿using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect : ContinuousEffect, IPowerModifyingEffect
    {
        private readonly int _power;
        private readonly Civilization[] _civilizations;

        public ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect effect) : base(effect)
        {
            _power = effect._power;
            _civilizations = effect._civilizations;
        }

        public ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(int power, params Civilization[] civilizations) : base(new CardFilters.OpponentsBattleZoneCivilizationCreatureFilter(civilizations), new Durations.Indefinite())
        {
            _power = power;
            _civilizations = civilizations;
        }

        public override ContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.Power += _power);
        }

        public override string ToString()
        {
            var joined = string.Join(" and ", _civilizations.Select(x => $"{x.ToString().ToLower()} creature"));
            return $"This creature gets +{_power} power for each {joined} your opponent has in the battle zone.";
        }
    }
}