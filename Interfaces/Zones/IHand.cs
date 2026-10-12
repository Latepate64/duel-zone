namespace Interfaces.Zones;

public interface IHand : IZone
{
    IEnumerable<ICard> CardsWithManaCost(int manaCost);
}
