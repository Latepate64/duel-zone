using Models;

namespace TestModels;

public class ChooseAndMoveCardsEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var expected = new ChooseAndMoveCardsEffect
        {
            CardFilter = new CardFilter()
        };

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}
