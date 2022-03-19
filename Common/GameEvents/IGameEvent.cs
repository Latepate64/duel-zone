namespace Common.GameEvents
{
    public interface IGameEvent : IIdentifiable
    {
        IGameEvent Copy();
    }
}