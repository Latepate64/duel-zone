﻿using System;

namespace Engine.Abilities
{
    /// <summary>
    /// An ability can be one of three things: An ability can be a characteristic an object has that lets it affect the game; An ability can be something that a player has that changes how the game affects the player.; An ability can be an activated or triggered ability on the stack.
    /// </summary>
    public abstract class Ability : IAbility
    {
        /// <summary>
        /// The source of an ability is the object that generated it. The source of an activated ability on the stack is the object whose ability was activated. The source of a triggered ability (other than a delayed triggered ability) on the stack, or one that has triggered and is waiting to be put on the stack, is the object whose ability triggered.
        /// </summary>
        public Guid Source { get; set; }

        public Guid Id { get; }

        /// <summary>
        /// 109.5. The words “you” and “your” on an object refer to the object’s controller, its would-be controller (if a player is attempting to play, cast, or activate it), or its owner (if it has no controller).
        /// </summary>
        public Guid Owner { get; set; }

        protected Ability()
        {
            Id = Guid.NewGuid();
        }

        protected Ability(IAbility ability)
        {
            Id = Guid.NewGuid();
            Owner = ability.Owner;
            Source = ability.Source;
        }

        public abstract IAbility Copy();

        public override abstract string ToString();

        protected static string UpperCaseFirstCharacter(string text)
        {
            return char.ToUpper(text[0]) + text[1..];
        }

        protected static string LowerCaseFirstCharacter(string text)
        {
            return char.ToLower(text[0]) + text[1..];
        }
    }
}
