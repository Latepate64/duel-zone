using Models;

namespace TestModels;

public class TapAllYourOpponentsCreaturesEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new CardFilter();
        var expected = new TapAllYourOpponentsCreaturesEffect
        {
            CardFilter = filter
        };

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}
