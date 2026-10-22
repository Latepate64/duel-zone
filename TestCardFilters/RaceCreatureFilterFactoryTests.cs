using CardFilters;
using Interfaces;

namespace TestCardFilters;

public class RaceCreatureFilterFactoryTests
{
    [Fact]
    public void CreatesCardFilter()
    {
        // Arrange
        var factory = new RaceCreatureFilterFactory();

        // Act
        var actual = factory.Create(Race.AngelCommand);

        // Assert
        Assert.IsType<ICardFilter>(actual, exactMatch: false);
    }

    [Fact]
    public void CreatesRaceCreatureFilterWithTwoRaces()
    {
        // Arrange
        var factory = new RaceCreatureFilterFactory();

        // Act
        var actual = factory.Create(Race.AngelCommand, Race.DemonCommand);

        // Assert
        Assert.IsType<ICardFilter>(actual, exactMatch: false);
    }
}
