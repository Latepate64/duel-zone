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
            try
            {
                // 608.2c The controller of the spell or ability follows its instructions in the order written.
                OneShotEffect.Apply(game, this);
            }
            catch (PlayerNotInGameException)
            { 
            }
        }
    }
}
