﻿using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    abstract class GetPowerAndDoubleBreakerEffect : CharacteristicModifyingEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        private readonly int _power;

        protected GetPowerAndDoubleBreakerEffect(GetPowerAndDoubleBreakerEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        protected GetPowerAndDoubleBreakerEffect(ICardFilter filter, int power, IDuration duration, params Condition[] conditions) : base(filter, duration, conditions)
        {
            _power = power;
        }

        public void AddAbility(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.AddGrantedAbility(new StaticAbilities.DoubleBreakerAbility()));
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.Power += _power);
        }
    }
}