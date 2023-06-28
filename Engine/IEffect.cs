using Engine.Abilities;
using System;

namespace Engine
{
    public interface IEffect
    {
        IAbility Ability { get; set; }
        IPlayer Applier { get; }
        ICard Source { get; }
        IGame Game { get; }
    }

    public abstract class Effect : IEffect
    {
        protected Effect()
        {
        }

        protected Effect(IEffect effect)
        {
            Ability = effect.Ability;
        }

        public IAbility Ability { get; set; }
        public IPlayer Applier => Ability.Controller;
        public ICard Source => Ability.Source;
        public IGame Game => Ability.Game;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        public override abstract string ToString();

        protected bool IsSourceOfAbility(ICard card)
        {
            return card == Source;
        }
    }
}
