using ContinuousEffects.Blocker;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.Blocker;

public class ThisCreatureHasBlockerEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new ThisCreatureHasBlockerEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void CreatureWithoutBlockerCannotBlock()
    {
        // Arrange
        var effect = new ThisCreatureHasBlockerEffect();
        var blocker = Mock.Of<ICreature>();
        var attacker = Mock.Of<ICreature>();

        // Act
        var actual = effect.CanBlock(blocker, attacker);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CreatureWithBlockerCanBlock()
    {
        // Arrange
        var blocker = Mock.Of<ICreature>();
        var attacker = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(blocker);
        var effect = new ThisCreatureHasBlockerEffect
        {
            Ability = ability.Object
        };

        // Act
        var actual = effect.CanBlock(blocker, attacker);

        // Assert
        Assert.True(actual);
    }
}