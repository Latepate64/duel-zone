using Models;
using Moq;

namespace TestModels;

public class SpellAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new MockEffect();
        var expected = new SpellAbility
        {
            Item = effect
        };

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}
