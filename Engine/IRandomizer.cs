namespace Engine;

public interface IRandomizer
{
    ICard[] Shuffle(ICard[] cards);
}
