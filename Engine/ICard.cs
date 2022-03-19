namespace Engine
{
    public interface ICard : Common.ICard
    {
        bool CanEvolveFrom(IGame game, ICard card);
    }
}