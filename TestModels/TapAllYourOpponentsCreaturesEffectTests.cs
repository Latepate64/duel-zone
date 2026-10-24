using Models;

namespace TestModels;

public class TapAllYourOpponentsCreaturesEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var expected = new TapAllYourOpponentsCreaturesEffect
        {
            CardFilter = new CardFilter()
        };

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}
