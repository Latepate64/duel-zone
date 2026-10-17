using Interfaces;

namespace CardFilters;

public class DragonFilterFactory : ICardFilterFactory
{
    public ICardFilter Create()
    {
        return new DragonFilter();
    }
}