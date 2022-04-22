﻿using Engine.Abilities;
using System;

namespace Engine
{
    public interface IEffect
    {
        IAbility Ability { get; set; }
        IPlayer Controller { get; set; }
        ICard Source { get; }
    }

    public abstract class Effect : IEffect
    {
        protected Effect()
        {
        }

        protected Effect(IEffect effect)
        {
            Ability = effect.Ability;
            Controller = effect.Controller;
        }

        public IPlayer Controller { get; set; }
        public IAbility Ability { get; set; }
        public ICard Source => Ability.SourceCard;

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
            return card == Ability.SourceCard;
        }

        protected IPlayer GetOpponent(IGame game)
        {
            return game.GetOpponent(Controller);
        }
    }
}
