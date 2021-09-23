using DuelMastersModels.Choices;
using DuelMastersModels.Effects.OneShotEffects;
using System.Collections.Generic;

namespace DuelMastersModels.Abilities
{
    /// <summary>
    /// Abstract class for spell, activated and trigger abilities. Non-static abilities are resolvable abilities.
    /// </summary>
    public abstract class NonStaticAbility : Ability
    {
        /// <summary>
        /// Abilities can generate one-shot effects or continuous effects.
        /// </summary>
        public Queue<OneShotEffect> Effects { get; private set; }

        /// <summary>
        /// The controller of a triggered ability on the stack (other than a delayed triggered ability) is the player who controlled the ability’s source when it triggered, or, if it had no controller, the player who owned the ability’s source when it triggered.
        /// </summary>
        public Player Controller { get; set; }

        protected NonStaticAbility(Queue<OneShotEffect> effects, Cards.Card source) : base(source)
        {
            Effects = effects;
        }

        public abstract Choice Resolve(Duel duel, Choice choice);
    }
}
