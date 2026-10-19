using Interfaces;

namespace CardFilters;

public class RaceCreatureFilterFactory : IRaceCreatureFilterFactory
{
    public ICardFilter Create(Race race)
    {
        return new RaceCreatureFilter(race);
    }

    public ICardFilter Create(Race race1, Race race2)
    {
        return new RaceCreatureFilter(race1, race2);
    }
}