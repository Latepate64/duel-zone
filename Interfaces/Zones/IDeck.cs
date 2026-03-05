namespace Interfaces.Zones;

public interface IDeck : IZone
{
    ICard TopCard { get; }

    IEnumerable<ICard> GetTopCards(int amount);
}
