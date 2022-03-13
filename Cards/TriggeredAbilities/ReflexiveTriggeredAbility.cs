﻿using Engine.Abilities;
using System;

namespace Cards.TriggeredAbilities
{
    /// <summary>
    /// 603.12.
    /// </summary>
    class ReflexiveTriggeredAbility : ResolvableAbility
    {
        public ReflexiveTriggeredAbility(OneShotEffect effect) : base(effect)
        {
        }

        public ReflexiveTriggeredAbility(ReflexiveTriggeredAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new ReflexiveTriggeredAbility(this);
        }

        public override string ToString()
        {
            return $"If you do, {OneShotEffect}";
        }
    }
}