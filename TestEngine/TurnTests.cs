using Engine;
using Engine.Steps;
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
        var phase = new Mock<IPhase>();
        phase.Setup(x => x.Copy()).Returns(phase.Object);
        var turn = new Turn(activePlayer, nonActivePlayer);
        turn.AddPhase(phase.Object);

        // Act
        var copy = turn.Copy();

        // Assert
        Assert.Equal(turn, copy);
    }
}
