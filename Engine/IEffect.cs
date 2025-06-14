using Engine.Abilities;
using System;

namespace Engine
{
    public interface IEffect
    {
        IAbility Ability { get; set; }
        Player Controller { get; }
        Card Source { get; }
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
        public Player Controller => Ability.Controller;
        public Card Source => Ability.Source;

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

        protected bool IsSourceOfAbility(Card card)
        {
            return card == Source;
        }

        protected Player GetOpponent(IGame game)
        {
            return game.GetOpponent(Controller);
        }
    }
}
