
namespace Engine.Abilities
{
    public abstract class ActivatedAbility : ResolvableAbility
    {
        protected ActivatedAbility(IOneShotEffect effect) : base(effect)
        {
        }

        protected ActivatedAbility(IResolvableAbility ability) : base(ability)
        {
        }
    }
}
