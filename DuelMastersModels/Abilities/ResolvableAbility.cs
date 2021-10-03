using DuelMastersModels.Choices;

namespace DuelMastersModels.Abilities
{
    public abstract class ResolvableAbility : Ability
    {
        public Resolvable Resolvable { get; set; }

        protected ResolvableAbility(Resolvable resolvable) : base()
        {
            Resolvable = resolvable;
        }

        protected ResolvableAbility(ResolvableAbility ability) : base(ability)
        {
            Resolvable = ability.Resolvable.Copy();
        }

        public Choice Resolve(Duel duel, Decision decision)
        {
            return Resolvable.Resolve(duel, decision);
        }
    }
}
