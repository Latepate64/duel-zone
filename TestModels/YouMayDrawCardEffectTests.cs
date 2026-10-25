using Models;

namespace TestModels;

public class YouMayDrawCardEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var expected = new YouMayDrawCardEffect();

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}
