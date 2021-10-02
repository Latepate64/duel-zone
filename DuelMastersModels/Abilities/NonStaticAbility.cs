using DuelMastersModels.Choices;

namespace DuelMastersModels.Abilities
{
    /// <summary>
    /// Abstract class for spell, activated and trigger abilities. Non-static abilities are resolvable abilities.
    /// </summary>
    public abstract class NonStaticAbility : Ability
    {
        protected NonStaticAbility() : base()
        {
        }

        protected NonStaticAbility(NonStaticAbility ability) : base(ability)
        {
        }

        public abstract Choice Resolve(Duel duel, Decision decision);
    }
}
