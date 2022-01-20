namespace DuelMastersModels.Abilities
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

        public void Resolve(Game game)
        {
            OneShotEffect.Apply(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                OneShotEffect.Dispose();
                OneShotEffect = null;
            }
        }
    }
}
