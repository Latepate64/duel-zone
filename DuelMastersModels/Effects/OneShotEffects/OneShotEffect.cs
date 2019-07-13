namespace DuelMastersModels.Effects.OneShotEffects
{
    public abstract class OneShotEffect : Effect
    {
        protected OneShotEffect() { }

        public abstract PlayerActions.PlayerAction Apply(Duel duel, Player player);
    }
}
