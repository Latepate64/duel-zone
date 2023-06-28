using System;

namespace Engine.Abilities
{
    /// <summary>
    /// 610.1. A one-shot effect does something just once and doesn’t have a duration.
    /// Examples include moving an object from one zone to another.
    /// </summary>
    public abstract class OneShotEffect : Effect, IOneShotEffect, IDisposable
    {
        protected OneShotEffect() { }

        protected OneShotEffect(IOneShotEffect effect) : base(effect)
        {
        }

        /// <summary>
        /// Applies the effect.
        /// </summary>
        /// <param name="game"></param>
        public abstract void Apply(IGame game);

        public abstract IOneShotEffect Copy();
    }
}
