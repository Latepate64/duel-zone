using Interfaces;

namespace CardFilters;

public class RaceCreatureFilterFactory : IRaceCreatureFilterFactory
{
    public ICardFilter Create(Race race)
    {
        return new RaceCreatureFilter(race);
    }
}