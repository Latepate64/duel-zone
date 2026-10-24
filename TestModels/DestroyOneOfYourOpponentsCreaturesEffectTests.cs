using Models;

namespace TestModels;

public class DestroyOneOfYourOpponentsCreaturesEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var expected = new DestroyOneOfYourOpponentsCreaturesEffect
        {
            CardFilter = new CardFilter()
        };

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}
