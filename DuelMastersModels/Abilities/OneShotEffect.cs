using System;

namespace DuelMastersModels.Abilities
{
    public abstract class OneShotEffect : IDisposable
    {
        public Guid Source { get; set; }
        public Guid Controller { get; set; }

        protected OneShotEffect() { }

        protected OneShotEffect(OneShotEffect effect)
        {
            Controller = effect.Controller;
            Source = effect.Source;
        }

        public abstract void Apply(Game game);

        public abstract OneShotEffect Copy();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
