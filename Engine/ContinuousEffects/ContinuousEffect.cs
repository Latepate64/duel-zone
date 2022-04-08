using Engine.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.ContinuousEffects
{
    /// <summary>
    /// 611.1. A continuous effect modifies characteristics of objects, modifies control of objects, or affects players or the rules of the game, for a fixed or indefinite period.
    /// </summary>
    public abstract class ContinuousEffect : ITimestampable, IContinuousEffect
    {
        /// <summary>
        /// Filter that can be applied to find cards affected by the effect.
        /// </summary>
        public ICardFilter Filter { get; set; }

        public Guid SourceAbility { get; set; }

        public int Timestamp { get; set; }

        protected ContinuousEffect(ICardFilter filter)
        {
            Filter = filter;
        }

        protected ContinuousEffect()
        {
        }

        protected ContinuousEffect(ContinuousEffect effect)
        {
            Filter = effect.Filter?.Copy();
            SourceAbility = effect.SourceAbility;
        }

        public abstract IContinuousEffect Copy();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Filter.Dispose();
                Filter = null;
                SourceAbility = Guid.Empty;
            }
        }

        public override abstract string ToString();

        protected IAbility GetSourceAbility(IGame game)
        {
            return game.GetAbility(SourceAbility);
        }

        protected bool IsSourceOfAbility(ICard card, IGame game)
        {
            return card.Id == GetSourceAbility(game).Source;
        }

        protected ICard GetSourceCard(IGame game)
        {
            return game.GetCard(GetSourceAbility(game).Source);
        }
    }
}
