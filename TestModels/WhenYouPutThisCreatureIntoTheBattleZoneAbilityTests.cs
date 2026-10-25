using Models;

namespace TestModels;

public class WhenYouPutThisCreatureIntoTheBattleZoneAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new MockEffect();
        var expected = new WhenYouPutThisCreatureIntoTheBattleZoneAbility
        {
            Item = effect
        };

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}
