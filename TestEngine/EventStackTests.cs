using Engine;
using Interfaces;
using Moq;
using Xunit;

namespace TestEngine;

public sealed class EventStackTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var e = new EventStack();

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Fact]
    public void HashCodesAreEqualForEqualStacks()
    {
        // Arrange
        var e = Mock.Of<IGameEventV2>();
        var first = new EventStack();
        first.Push(e);
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
        var e = new EventStack();
        var other = new object();

        // Act
        var equal = e.Equals(other);
        
        // Assert
        Assert.False(equal);
    }

    [Fact]
    public void DoesNotEqualStackWithDifferentEvents()
    {
        // Arrange
        var first = new EventStack();
        var second = first.Copy();
        first.Push(Mock.Of<IGameEventV2>());

        // Act
        var equal = first.Equals(second);
        
        // Assert
        Assert.False(equal);
    }

    [Fact]
    public void CheckEmptinessWithPushingAndPopping()
    {
        // Arrange
        var stack = new EventStack();
        var emptyBeforePush = stack.IsEmpty;
        stack.Push(Mock.Of<IGameEventV2>());
        var emptyAfterPush = stack.IsEmpty;
        stack.Pop();

        // Act
        var emptyAfterPop = stack.IsEmpty;
        
        // Assert
        Assert.True(emptyBeforePush);
        Assert.False(emptyAfterPush);
        Assert.True(emptyAfterPop);
    }

    [Fact]
    public void TopEventOfStackHappens()
    {
        // Arrange
        var stack = new EventStack();
        var e = new Mock<IGameEventV2>();
        var state = Mock.Of<IGameState>();
        e.Setup(x => x.Happen(state));
        stack.Push(e.Object);

        // Act
        var actual = stack.Happen(state);
        
        // Assert
        Assert.Empty(actual);
        e.Verify(x => x.Happen(state));
    }
}