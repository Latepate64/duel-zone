namespace Engine.Abilities
{
    public abstract class ResolvableAbility : Ability, IResolvableAbility
    {
        public IOneShotEffect OneShotEffect { get; set; }

        protected ResolvableAbility(IOneShotEffect effect) : base()
        {
            OneShotEffect = effect;
        }

        protected ResolvableAbility(ResolvableAbility ability) : base(ability)
        {
            OneShotEffect = ability.OneShotEffect.Copy();
        }

        /// <summary>
        /// 608.2c The controller of the ability follows its instructions in the order written.
        /// </summary>
        /// <param name="game"></param>
        public virtual void Resolve(IGame game)
        {
            OneShotEffect.SourceAbility = Id;
            OneShotEffect.Apply(game, this);
        }
    }
}
