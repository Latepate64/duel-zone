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
        state.SetupGet(x => x.ActivePlayer).Returns(winner);
        state.SetupGet(x => x.NonActivePlayer).Returns(loser);

        // Act
        var actual = lose.Happen(state.Object);
        
        // Assert
        state.Verify(x => x.Losers.Add(loser));
        state.VerifySet(x => x.Winner = winner);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEvents()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var lose = new LoseGameEvent(player.Object);
        var second = lose.Copy();
        var expected = second.GetHashCode();

        // Act
        var actual = lose.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoesNotEqualObjectOfDifferentType()
    {
        // Arrange
        var e = new LoseGameEvent(Mock.Of<IPlayerV2>());
        var other = new object();

        // Act
        var equal = e.Equals(other);
        
        // Assert
        Assert.False(equal);
    }

    [Fact]
    public void DoesNotEqualEventWithDifferentPlayer()
    {
        // Arrange
        var first = new LoseGameEvent(Mock.Of<IPlayerV2>());
        var second = new LoseGameEvent(Mock.Of<IPlayerV2>());

        // Act
        var equal = first.Equals(second);
        
        // Assert
        Assert.False(equal);
    }
}