using Interfaces;
using Models;
using Moq;

namespace TestModels;

public class MoveCardEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var card = new Mock<ICard>();
        card.Setup(x => x.Copy()).Returns(card.Object);
        var expected = new MoveCardEvent(
            card.Object, Models.ZoneType.Battlezone, Models.ZoneType.Graveyard);

        // Act
        var actual = expected.Copy();

        // Assert
        Assert.Equal(expected, actual);
    }
}
