namespace Interfaces;

public interface IRandomizer
{
    IRandomizer Copy();
    void Shuffle(List<ICard> cards);
}
