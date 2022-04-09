﻿using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class AuraBlastEffect : OneShotEffect
    {
        private readonly int _power;

        public AuraBlastEffect(int power) : base()
        {
            _power = power;
        }

        public AuraBlastEffect(AuraBlastEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(_power, game.BattleZone.GetCreatures(source.Controller).ToArray()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new AuraBlastEffect(this);
        }

        public override string ToString()
        {
            return $"Each of your creatures in the battle zone gets \"power attacker +{_power}\" until the end of the turn.";
        }
    }
}
