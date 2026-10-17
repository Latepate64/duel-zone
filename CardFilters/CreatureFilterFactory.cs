using Interfaces;

namespace CardFilters;

public class CreatureFilterFactory : ICardFilterFactory
{
    public ICardFilter Create()
    {
        return new CreatureFilter();
    }
}
