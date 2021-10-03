using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Abilities
{
    public abstract class Resolvable
    {
        public Guid Source { get; set; }
        public Guid Controller { get; set; }

        protected Resolvable() { }

        protected Resolvable(Resolvable resolvable)
        {
            Controller = resolvable.Controller;
        }

        public abstract Choice Resolve(Duel duel, Decision decision);

        public abstract Resolvable Copy();
    }
}
