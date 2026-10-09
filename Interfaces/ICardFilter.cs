namespace Interfaces;

public interface ICardFilter
{
    bool Match(ICard card);
    ICardFilter Copy();
}