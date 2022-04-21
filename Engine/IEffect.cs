using Engine.Abilities;
using System;

namespace Engine
{
    public interface IEffect
    {
        Guid SourceAbility { get; set; }
        IPlayer Controller { get; set; }
        IAbility Source { get; set; }
    }

    public abstract class Effect : IEffect
    {
        protected Effect()
        {
        }

        protected Effect(IEffect effect)
        {
            SourceAbility = effect.SourceAbility;
        }

        public Guid SourceAbility { get; set; }
        public IPlayer Controller { get; set; }
        public IAbility Source { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                SourceAbility = Guid.Empty;
            }
        }

        public override abstract string ToString();

        protected IAbility GetSourceAbility(IGame game)
        {
            return Source;
        }

        protected bool IsSourceOfAbility(ICard card, IGame game)
        {
            return card.Id == Source.Source;
        }

        protected ICard GetSourceCard(IGame game)
        {
            return game.GetCard(Source.Source);
        }

        protected IPlayer GetController(IGame game)
        {
            return Controller;
        }

        protected IPlayer GetOpponent(IGame game)
        {
            return game.GetOpponent(Controller);
        }
    }
}
