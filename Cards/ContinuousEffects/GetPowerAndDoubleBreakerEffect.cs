﻿using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.ContinuousEffects
{
    abstract class GetPowerAndDoubleBreakerEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        private readonly int _power;

        protected GetPowerAndDoubleBreakerEffect(GetPowerAndDoubleBreakerEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        protected GetPowerAndDoubleBreakerEffect(int power) : base()
        {
            _power = power;
        }

        public void AddAbility()
        {
            GetAffectedCards().ForEach(x => x.AddGrantedAbility(new StaticAbilities.DoubleBreakerAbility()));
        }

        public void ModifyPower()
        {
            GetAffectedCards().ForEach(x => x.Power += _power);
        }

        protected abstract List<ICard> GetAffectedCards();
    }
}
