using Models;

namespace TestModels;

public class CreatureTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var expected = new Creature
        {
            Abilities = [],
            Civilizations = [],
            Cost = 1,
            Name = "Test",
            Power = 1000,
            Races = [],
        };

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}