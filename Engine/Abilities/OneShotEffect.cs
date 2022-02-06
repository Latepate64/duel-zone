using System;

namespace Engine.Abilities
{
    public abstract class OneShotEffect : IDisposable
    {
        protected OneShotEffect() { }

        public abstract void Apply(Game game, Ability source);

        public abstract OneShotEffect Copy();

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
