namespace Engine.ContinuousEffects
{
    public abstract class BlockerEffect : ContinuousEffect
    {
        private readonly ICardFilter _blockableCreatures;

        protected BlockerEffect(ICardFilter filter, ICardFilter blockableCreatures, IDuration duration, params Condition[] conditions) : base(filter, duration, conditions)
        {
            _blockableCreatures = blockableCreatures;
        }

        protected BlockerEffect(BlockerEffect effect) : base(effect)
        {
            _blockableCreatures = effect._blockableCreatures.Copy();
        }

        internal bool Applies(ICard attacker, IGame game)
        {
            return _blockableCreatures.Applies(attacker, game, game.GetOwner(attacker));
        }
    }
}
