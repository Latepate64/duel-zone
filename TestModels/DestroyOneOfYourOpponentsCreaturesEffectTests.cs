using Models;

namespace TestModels;

public class DestroyOneOfYourOpponentsCreaturesEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var expected = new DestroyOneOfYourOpponentsCreaturesEffect();

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}
