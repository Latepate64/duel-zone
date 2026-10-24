using Models;

namespace TestModels;

public class ShieldTriggerAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var expected = new ShieldTriggerAbility();

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}
