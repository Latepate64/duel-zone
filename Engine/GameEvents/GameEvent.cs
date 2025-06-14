namespace Engine.GameEvents
{
    public abstract class GameEvent : IGameEvent
    {
        public System.Guid Id { get; }

        public virtual Player GetApplier(IGame game)
        {
            throw new System.NotImplementedException();
        }

        public abstract void Happen(IGame game);
        public abstract override string ToString();
    }
}
