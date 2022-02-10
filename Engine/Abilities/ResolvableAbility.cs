namespace Engine.Abilities
{
    public abstract class ResolvableAbility : Ability
    {
        public OneShotEffect OneShotEffect { get; set; }

        protected ResolvableAbility(OneShotEffect effect) : base()
        {
            OneShotEffect = effect;
        }

        protected ResolvableAbility(ResolvableAbility ability) : base(ability)
        {
            OneShotEffect = ability.OneShotEffect.Copy();
        }

        public virtual void Resolve(Game game)
        {
            OneShotEffect.Apply(game, this);
        }
    }
}
