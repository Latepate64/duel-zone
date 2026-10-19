namespace Interfaces.Zones;

public interface IGraveyard : IZone
{
    IEnumerable<ICard> GetOtherCards(ICard source, ICardFilter filter);
}
