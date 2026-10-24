using Models;
using Moq;

namespace TestModels;

public class TapAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new MockEffect();
        var expected = new TapAbility
        {
            Item = effect
        };

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}