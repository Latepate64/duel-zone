using DuelMastersModels.Durations;
using DuelMastersModels.GameEvents;
using System.Collections.Generic;

namespace DuelMastersModels.ContinuousEffects
{
    public abstract class CharacteristicModifyingEffect : ContinuousEffect
    {
        protected CharacteristicModifyingEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {
        }

        protected CharacteristicModifyingEffect(IEnumerable<CardFilter> filters, Duration duration) : base(filters, duration)
        {
        }

        protected CharacteristicModifyingEffect(CharacteristicModifyingEffect effect) : base(effect)
        {
        }

        /// <summary>
        /// Starts modifying characteristic of the affected cards.
        /// </summary>
        /// <param name="game"></param>
        public abstract void Start(Game game);

        /// <summary>
        /// Stops modifying characteristics of the affected cards.
        /// </summary>
        /// <param name="game"></param>
        public abstract void End(Game game);

        /// <summary>
        /// Considers a game event which could modify either the collection of affected cards or the characteristics of affected cards.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="e"></param>
        public abstract void Update(Game game, GameEvent e);
    }
}
