using Interfaces.ContinuousEffects;
namespace Interfaces;

public interface IGame
{
    public IContinuousEffects ContinuousEffects { get; }
    IEnumerable<ICard> GetAllCards();
    int GetTimestamp();
}
