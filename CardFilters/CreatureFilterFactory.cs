using Interfaces;

namespace CardFilters;

public class CreatureFilterFactory
{
    public ICardFilter Create()
    {
        return new CreatureFilter();
    }
}