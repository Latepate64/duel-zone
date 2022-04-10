namespace Engine.GameEvents
{
    public abstract class GameEvent : IGameEvent
    {
        public System.Guid Id { get; }

        public abstract void Happen(IGame game);
        public abstract override string ToString();
    }
}
