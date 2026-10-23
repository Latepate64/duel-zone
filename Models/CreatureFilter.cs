using Interfaces;

namespace Models;

public partial class CreatureFilter : ICardFilter
{
    public ICardFilter Copy()
    {
        return new CreatureFilter();
    }

    public bool Match(ICard card)
    {
        return card is ICreature;
    }
}
