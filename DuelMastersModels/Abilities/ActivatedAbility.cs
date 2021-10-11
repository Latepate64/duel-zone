
namespace DuelMastersModels.Abilities
{
    public abstract class ActivatedAbility : ResolvableAbility
    {
        protected ActivatedAbility(Resolvable resolvable) : base(resolvable)
        {
        }

        protected ActivatedAbility(ResolvableAbility ability) : base(ability)
        {
        }
    }
}
