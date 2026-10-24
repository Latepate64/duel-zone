using Models;

namespace TestModels;

public class SpellTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var expected = new Spell
        {
            Abilities = [],
            Civilizations = [],
            Cost = 1,
            Name = "Test",
        };

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}