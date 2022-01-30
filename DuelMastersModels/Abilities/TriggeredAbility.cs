using Engine.GameEvents;
using System;

namespace Engine.Abilities
{
    /// <summary>
    /// 603.1. Triggered abilities have a trigger condition and an effect. They are written as “[When/Whenever/At] [trigger condition or event], [effect]. [Instructions (if any).]”
    /// </summary>
    public abstract class TriggeredAbility : ResolvableAbility
    {
        protected TriggeredAbility(OneShotEffect effect) : base(effect)
        {
        }

        protected TriggeredAbility(TriggeredAbility ability) : base(ability)
        {
        }

        /// <summary>
        /// 603.2. Whenever a game event or game state matches a triggered ability’s trigger event, that ability automatically triggers.
        /// The ability doesn’t do anything at this point.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public TriggeredAbility Trigger(Guid source, Guid owner)
        {
            var copy = Copy() as TriggeredAbility;
            copy.Source = source;
            copy.Owner = owner;
            return copy;
        }

        public abstract bool CanTrigger(GameEvent gameEvent, Game game);

        /// <summary>
        /// 603.4. A triggered ability may read “When/Whenever/At [trigger event], if [condition], [effect].”
        /// When the trigger event occurs, the ability checks whether the stated condition is true.
        /// The ability triggers only if it is; otherwise it does nothing.
        /// If the ability triggers, it checks the stated condition again as it resolves.
        /// If the condition isn’t true at that time, the ability is removed from the stack and does nothing.
        /// Note that this mirrors the check for legal targets.
        /// This rule is referred to as the “intervening ‘if’ clause” rule.
        /// (The word “if” has only its normal English meaning anywhere else in the text of a card; this rule only applies to an “if” that immediately follows a trigger condition.)
        /// </summary>
        public virtual bool CheckInterveningIfClause(Game game)
        {
            return true;
        }

        /// <summary>
        /// 608.2a If a triggered ability has an intervening “if” clause, it checks whether the clause’s condition is true.
        /// If it isn’t, the ability is removed from the stack and does nothing.
        /// Otherwise, it continues to resolve. See rule 603.4.
        /// </summary>
        /// <param name="game"></param>
        public override void Resolve(Game game)
        {
            if (CheckInterveningIfClause(game))
            {
                OneShotEffect.Apply(game, this);
            }
        }
    }
}
