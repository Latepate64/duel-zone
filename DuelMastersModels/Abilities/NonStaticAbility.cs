using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Abilities
{
    /// <summary>
    /// Abstract class for spell, activated and trigger abilities. Non-static abilities are resolvable abilities.
    /// </summary>
    public abstract class NonStaticAbility : Ability
    {
        /// <summary>
        /// The controller of a triggered ability on the stack (other than a delayed triggered ability) is the player who controlled the ability’s source when it triggered, or, if it had no controller, the player who owned the ability’s source when it triggered.
        /// </summary>
        public Guid Controller { get; set; }

        protected NonStaticAbility(Guid source) : base(source)
        {
        }

        protected NonStaticAbility(NonStaticAbility ability) : base(ability)
        {
            Controller = ability.Controller;
        }

        public abstract Choice Resolve(Duel duel, Decision choice);
    }
}
