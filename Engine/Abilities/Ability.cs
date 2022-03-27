using System;

namespace Engine.Abilities
{
    /// <summary>
    /// An ability can be one of three things: An ability can be a characteristic an object has that lets it affect the game; An ability can be something that a player has that changes how the game affects the player.; An ability can be an activated or triggered ability on the stack.
    /// </summary>
    public abstract class Ability : IAbility
    {
        /// <summary>
        /// 113.7.
        /// The source of an ability is the object that generated it.
        /// </summary>
        public Guid Source { get; set; }

        public Guid Id { get; }

        /// <summary>
        /// 113.8.
        /// The controller of an activated ability on the stack is the player who activated it.
        /// The controller of a triggered ability on the stack (other than a delayed triggered ability)
        /// is the player who controlled the ability’s source when it triggered, or, if it had no controller,
        /// the player who owned the ability’s source when it triggered.
        /// </summary>
        public Guid Controller { get; set; }

        protected Ability()
        {
            Id = Guid.NewGuid();
        }

        protected Ability(IAbility ability)
        {
            Id = Guid.NewGuid();
            Controller = ability.Controller;
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
