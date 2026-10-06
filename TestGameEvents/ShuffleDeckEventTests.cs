using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class ShuffleDeckEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var random = Mock.Of<IRandomizer>();
        var e = new ShuffleDeckEvent(player.Object, random);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Fact]
    public void ShufflesDeck()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        var random = Mock.Of<IRandomizer>();
        player.Setup(x => x.Deck.Shuffle(random));
        var e = new ShuffleDeckEvent(player.Object, random);

        // Act
        var events = e.Happen(Mock.Of<IGameState>());
        
        // Assert
        player.Verify(x => x.Deck.Shuffle(random));
        Assert.Empty(events);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEvents()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var shuffle = new ShuffleDeckEvent(player.Object,
            Mock.Of<IRandomizer>());
        var second = shuffle.Copy();
        var expected = second.GetHashCode();

        // Act
        var actual = shuffle.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoesNotEqualObjectOfDifferentType()
    {
        // Arrange
        var e = new ShuffleDeckEvent(Mock.Of<IPlayerV2>(),
            Mock.Of<IRandomizer>());
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
        var ramdom = Mock.Of<IRandomizer>();
        var first = new ShuffleDeckEvent(Mock.Of<IPlayerV2>(), ramdom);
        var second = new ShuffleDeckEvent(Mock.Of<IPlayerV2>(), ramdom);

        // Act
        var equal = first.Equals(second);
        
        // Assert
        Assert.False(equal);
    }
}