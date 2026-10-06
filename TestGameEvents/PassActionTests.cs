using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class PassActionTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var e = new PassAction(player.Object);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Fact]
    public void NothingHappens()
    {
        // Arrange
        var e = new PassAction(Mock.Of<IPlayerV2>());

        // Act
        var events = e.Happen(Mock.Of<IGameState>());
        
        // Assert
        Assert.Empty(events);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEvents()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var pass = new PassAction(player.Object);
        var second = pass.Copy();
        var expected = second.GetHashCode();

        // Act
        var actual = pass.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoesNotEqualObjectOfDifferentType()
    {
        // Arrange
        var e = new PassAction(Mock.Of<IPlayerV2>());
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
        var first = new PassAction(Mock.Of<IPlayerV2>());
        var second = new PassAction(Mock.Of<IPlayerV2>());

        // Act
        var equal = first.Equals(second);
        
        // Assert
        Assert.False(equal);
    }

    [Fact]
    public void Validate()
    {
        // Arrange
        var pass = new PassAction(Mock.Of<IPlayerV2>());

        // Act + Assert
        pass.Validate(Mock.Of<IPassableGameEvent>());
    }
}