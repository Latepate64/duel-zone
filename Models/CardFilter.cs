using Interfaces;

namespace Models;

public partial class CardFilter : ICardFilter
{
    public ICardFilter Copy()
    {
        return new CardFilter();
    }

    public bool Match(ICard card)
    {
        return true;
    }
}