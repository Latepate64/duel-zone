using DuelMastersModels.Choices;

namespace DuelMastersModels.Abilities
{
    public abstract class ResolvableAbility : Ability
    {
        protected ResolvableAbility() : base()
        {
        }

        protected ResolvableAbility(ResolvableAbility ability) : base(ability)
        {
        }

        public abstract Choice Resolve(Duel duel, Decision decision);
    }
}
