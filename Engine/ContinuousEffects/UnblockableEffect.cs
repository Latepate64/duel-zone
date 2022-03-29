namespace Engine.ContinuousEffects
{
    public abstract class UnblockableEffect : ContinuousEffect
    {
        private ICardFilter _creaturesThatCannotBlock;

        protected UnblockableEffect(ICardFilter filter, IDuration duration, ICardFilter blockerFilter, params Condition[] conditions) : base(filter, duration, conditions)
        {
            _creaturesThatCannotBlock = blockerFilter;
        }

        protected UnblockableEffect(UnblockableEffect effect) : base(effect)
        {
            _creaturesThatCannotBlock = effect._creaturesThatCannotBlock;
        }

        internal bool Applies(ICard blocker, IGame game)
        {
            return _creaturesThatCannotBlock.Applies(blocker, game, game.GetPlayer(blocker.Owner));
        }
    }
}
