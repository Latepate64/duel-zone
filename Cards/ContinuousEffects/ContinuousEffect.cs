using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System;

namespace Cards.ContinuousEffects
{
    /// <summary>
    /// 611.1. A continuous effect modifies characteristics of objects, modifies control of objects, or affects players or the rules of the game, for a fixed or indefinite period.
    /// </summary>
    public abstract class ContinuousEffect : IContinuousEffect, ITimestampable
    {
        public Guid SourceAbility { get; set; }
        public int Timestamp { get; set; }

        protected ContinuousEffect()
        {
        }

        protected ContinuousEffect(IContinuousEffect effect)
        {
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
                SourceAbility = Guid.Empty;
            }
        }

        public override abstract string ToString();

        protected IAbility GetSourceAbility(IGame game)
        {
            IAbility ability = game.GetAbility(SourceAbility);
            return ability;
        }

        protected bool IsSourceOfAbility(ICard card, IGame game)
        {
            var ability = GetSourceAbility(game);
            return card.Id == ability.Source;
        }

        protected ICard GetSourceCard(IGame game)
        {
            return game.GetCard(GetSourceAbility(game).Source);
        }

        protected IPlayer GetController(IGame game)
        {
            return GetSourceAbility(game).GetController(game);
        }
    }
}
