using ContinuousEffects;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects;

public class ThisCreatureBlocksIfAbleEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new ThisCreatureBlocksIfAbleEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void CreatureBlocksIfAble()
    {
        // Arrange
        var blocker = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(blocker);
        var effect = new ThisCreatureBlocksIfAbleEffect()
        {
            Ability = ability.Object
        };
        var attacker = Mock.Of<ICreature>();

        // Act
        var actual = effect.BlocksIfAble(blocker, attacker, Mock.Of<IGame>());

        // Assert
        Assert.True(actual);
    }
}