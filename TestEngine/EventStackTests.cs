using System;
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
        var e = new EventStack<IGameEvent, IGameEvent>(Mock.Of<IServiceProvider>());

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Fact]
    public void HashCodesAreEqualForEqualStacks()
    {
        // Arrange
        var e = Mock.Of<IGameEvent>();
        var first = new EventStack<IGameEvent, IGameEvent>(Mock.Of<IServiceProvider>());
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
        var e = new EventStack<IGameEvent, IGameEvent>(Mock.Of<IServiceProvider>());
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
        var first = new EventStack<IGameEvent, IGameEvent>(Mock.Of<IServiceProvider>());
        var second = first.Copy();
        first.Push(Mock.Of<IGameEvent>());

        // Act
        var equal = first.Equals(second);
        
        // Assert
        Assert.False(equal);
    }

    [Fact]
    public void CheckEmptinessWithPushingAndPopping()
    {
        // Arrange
        var stack = new EventStack<IGameEvent, IGameEvent>(Mock.Of<IServiceProvider>());
        var emptyBeforePush = stack.IsEmpty;
        stack.Push(Mock.Of<IGameEvent>());
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
        var player = Mock.Of<IPlayer>();
        var state = new Mock<IGameState>();
        state.SetupGet(x => x.ActivePlayer).Returns(player);
        var gameEvent = Mock.Of<IGameEvent>();
        var newEvent = Mock.Of<IGameEvent>();
        var resolver = new Mock<IEventResolver<IGameEvent, IGameEvent>>();
        resolver.Setup(x => x.Resolve(state.Object, player, gameEvent)).Returns([newEvent]);
        var provider = new Mock<IServiceProvider>();
        provider.Setup(x => x.GetService(typeof(IEventResolver<IGameEvent, IGameEvent>))).Returns(
            resolver.Object);
        var stack = new EventStack<IGameEvent, IGameEvent>(provider.Object);
        stack.Push(gameEvent);

        // Act
        var actual = stack.Happen(state.Object);
        
        // Assert
        Assert.Single(actual, newEvent);
    }
}