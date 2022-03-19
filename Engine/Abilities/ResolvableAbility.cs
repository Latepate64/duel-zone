namespace Engine.Abilities
{
    public abstract class ResolvableAbility : Ability, IResolvableAbility
    {
        public IOneShotEffect OneShotEffect { get; set; }

        protected ResolvableAbility(IOneShotEffect effect) : base()
        {
            OneShotEffect = effect;
        }

        protected ResolvableAbility(IResolvableAbility ability) : base(ability)
        {
            OneShotEffect = ability.OneShotEffect.Copy();
        }

        public virtual void Resolve(IGame game)
        {
            OneShotEffect.Apply(game, this);
        }
    }
}
