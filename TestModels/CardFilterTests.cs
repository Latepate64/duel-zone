using Interfaces;
using Models;
using Moq;

namespace TestModels;

public class CardFilterTests
{
    [Fact]
    public void MatchCard()
    {
        // Arrange
        var filter = new CardFilter { Type = CardFilterType.Card };

        // Act
        var actual = filter.Match(Mock.Of<ICard>());

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void MatchCreature()
    {
        // Arrange
        var filter = new CardFilter { Type = CardFilterType.Creature };

        // Act
        var actual = filter.Match(Mock.Of<ICreature>());

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void MatchSpell()
    {
        // Arrange
        var filter = new CardFilter { Type = CardFilterType.Spell };

        // Act
        var actual = filter.Match(Mock.Of<ISpell>());

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void MatchBlocker()
    {
        // Arrange
        var filter = new CardFilter { Type = CardFilterType.Blocker };
        var blocker = new Mock<ICreature>();
        blocker.SetupGet(x => x.HasBlocker).Returns(true);

        // Act
        var actual = filter.Match(blocker.Object);

        // Assert
        Assert.True(actual);
    }
}