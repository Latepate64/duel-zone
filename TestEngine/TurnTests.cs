using Engine;
using Moq;
using Xunit;

namespace TestEngine;

public class TurnTests
{
    [Fact]
    public void Copy()
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayer>();
        var nonActivePlayer = Mock.Of<IPlayer>();
        var turn = new Turn(activePlayer, nonActivePlayer);

        // Act
        var copy = turn.Copy();

        // Assert
        Assert.Equal(turn, copy);
    }
}
