namespace Common.GameEvents
{
    public interface ICardEvent : IGameEvent
    {
        ICard Card { get; set; }
    }
}