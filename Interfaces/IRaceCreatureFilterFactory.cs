namespace Interfaces;

public interface IRaceCreatureFilterFactory
{
    ICardFilter Create(Race race);
}