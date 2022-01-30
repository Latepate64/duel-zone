
namespace Engine.Abilities
{
    public abstract class ActivatedAbility : ResolvableAbility
    {
        protected ActivatedAbility(OneShotEffect effect) : base(effect)
        {
        }

        protected ActivatedAbility(ResolvableAbility ability) : base(ability)
        {
        }
    }
}
