using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class LoseGameEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var lose = new LoseGameEvent(player.Object);

        // Act
        var actual = lose.Copy();
        
        // Assert
        Assert.Equal(lose, actual);
    }

    [Fact]
    public void LoserIsUpdatedToStateAndNoOneWins()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var lose = new LoseGameEvent(player);
        var state = new Mock<IGameState>();
        state.Setup(x => x.Losers.Add(player));

        // Act
        var actual = lose.Happen(state.Object);
        
        // Assert
        state.Verify(x => x.Losers.Add(player));
    }

    [Fact]
    public void LoserIsUpdatedToStateAndAnotherPlayerWins()
    {
        // Arrange
        var loser = Mock.Of<IPlayerV2>();
        var winner = Mock.Of<IPlayerV2>();
        var lose = new LoseGameEvent(loser);
        var state = new Mock<IGameState>();
        state.Setup(x => x.Losers.Add(loser));
        state.SetupGet(x => x.Players).Returns([loser, winner]);

        // Act
        var actual = lose.Happen(state.Object);
        
        // Assert
        state.Verify(x => x.Losers.Add(loser));
        state.VerifySet(x => x.Winner = winner);
    }
}