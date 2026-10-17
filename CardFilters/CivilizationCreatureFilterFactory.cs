using Interfaces;

namespace CardFilters;

public class CivilizationCreatureFilterFactory
{
    public ICardFilter Create(Civilization civilization)
    {
        return new CivilizationCreatureFilter(civilization);
    }
}