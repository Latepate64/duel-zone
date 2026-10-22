using Interfaces;

namespace CardFilters;

public class CivilizationCreatureFilterFactory
{
    public ICardFilter Create(Civilization civilization)
    {
        return new CivilizationCreatureFilter(civilization);
    }

    public ICardFilter Create(Civilization civilization1, Civilization civilization2)
    {
        return new CivilizationCreatureFilter(civilization1, civilization2);
    }
}