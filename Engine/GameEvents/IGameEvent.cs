namespace Engine.GameEvents
{
    public interface IGameEvent
    {
        System.Guid Id { get; }

        void Happen(IGame game);
    }
}
