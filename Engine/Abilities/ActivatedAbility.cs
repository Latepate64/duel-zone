
namespace Engine.Abilities
{
    public abstract class ActivatedAbility : ResolvableAbility
    {
        protected ActivatedAbility(IOneShotEffect effect) : base(effect)
        {
        }

        protected ActivatedAbility(ActivatedAbility ability) : base(ability)
        {
        }
    }
}
