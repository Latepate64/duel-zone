using Interfaces;
using Models;
using Moq;

namespace TestModels;

public class TapCardEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var card = new Mock<ICard>();
        card.Setup(x => x.Copy()).Returns(card.Object);
        var expected = new TapCardEvent(card.Object);

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}