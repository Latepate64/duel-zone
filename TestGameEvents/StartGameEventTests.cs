using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class StartGameEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var otherPlayer = new Mock<IPlayerV2>();
        otherPlayer.Setup(x => x.Copy()).Returns(otherPlayer.Object);
        var random = Mock.Of<IRandomizer>();
        var e = new StartGameEvent(
            player.Object, otherPlayer.Object, random);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Fact]
    public void Happen()
    {
        // Arrange
        var random = Mock.Of<IRandomizer>();
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Deck.Shuffle(random));
        var otherPlayer = new Mock<IPlayerV2>();
        otherPlayer.Setup(x => x.Deck.Shuffle(random));
        var e = new StartGameEvent(
            player.Object, otherPlayer.Object, random);
        var state = Mock.Of<IGameState>();

        // Act
        var events = e.Happen(state);
        
        // Assert
        Assert.Empty(events);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEvents()
    {
        // Arrange
        var startingPlayer = new Mock<IPlayerV2>();
        startingPlayer.Setup(x => x.Copy()).Returns(startingPlayer.Object);
        var otherPlayer = new Mock<IPlayerV2>();
        otherPlayer.Setup(x => x.Copy()).Returns(otherPlayer.Object);
        var random = Mock.Of<IRandomizer>();
        var first = new StartGameEvent(startingPlayer.Object,
            otherPlayer.Object, random);
        var second = first.Copy();
        var expected = second.GetHashCode();

        // Act
        var actual = first.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoesNotEqualObjectOfDifferentType()
    {
        // Arrange
        var e = new StartGameEvent(
            Mock.Of<IPlayerV2>(),
            Mock.Of<IPlayerV2>(),
            Mock.Of<IRandomizer>());
        var other = new object();

        // Act
        var equal = e.Equals(other);
        
        // Assert
        Assert.False(equal);
    }

    [Fact]
    public void DoesNotEqualEventWithDifferentStartingPlayer()
    {
        // Arrange
        var otherPlayer = Mock.Of<IPlayerV2>();
        var first = new StartGameEvent(
            Mock.Of<IPlayerV2>(),
            otherPlayer,
            Mock.Of<IRandomizer>());
        var second = new StartGameEvent(
            Mock.Of<IPlayerV2>(),
            otherPlayer,
            Mock.Of<IRandomizer>());

        // Act
        var equal = first.Equals(second);
        
        // Assert
        Assert.False(equal);
    }

    [Fact]
    public void DoesNotEqualEventWithDifferentOtherPlayer()
    {
        // Arrange
        var startingPlayer = Mock.Of<IPlayerV2>();
        var first = new StartGameEvent(
            startingPlayer,
            Mock.Of<IPlayerV2>(),
            Mock.Of<IRandomizer>());
        var second = new StartGameEvent(
            startingPlayer,
            Mock.Of<IPlayerV2>(),
            Mock.Of<IRandomizer>());

        // Act
        var equal = first.Equals(second);
        
        // Assert
        Assert.False(equal);
    }
}