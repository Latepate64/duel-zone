using Models;

namespace TestModels;

public class DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var expected = new DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect();

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}
