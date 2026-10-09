using Cards.DM01;

namespace TestCards;

public class AquaHulcusTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var aquaHulcus = new AquaHulcus();

        // Act
        var copy = aquaHulcus.Copy();

        // Assert
        Assert.Equal(aquaHulcus, copy);
    }
}
