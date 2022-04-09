﻿using System;

namespace Engine.Abilities
{
    /// <summary>
    /// 610.1. A one-shot effect does something just once and doesn’t have a duration.
    /// Examples include moving an object from one zone to another.
    /// </summary>
    public abstract class OneShotEffect : IDisposable, IOneShotEffect
    {
        protected OneShotEffect() { }

        protected OneShotEffect(OneShotEffect effect) { }

        /// <summary>
        /// Applies the effect.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="source">Ability that created the effect.</param>
        /// <returns>Any object that represents usable information of whatever happened during the effect (such as did the player take an action or what cards were affected). This information may be applied for reflexive triggered abilities (see rule 603.12.). Returns null if no information of what happened is of use.</returns>
        public abstract object Apply(IGame game, IAbility source);

        public abstract IOneShotEffect Copy();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public override abstract string ToString();
    }
}
