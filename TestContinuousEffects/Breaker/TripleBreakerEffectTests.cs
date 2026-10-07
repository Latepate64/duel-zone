using ContinuousEffects.Breaker;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.Breaker;

public class TripleBreakerEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new TripleBreakerEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void CreatureWithoutTripleBreakerBreaksOneShield()
    {
        // Arrange
        var effect = new TripleBreakerEffect();
        var creature = Mock.Of<ICreature>();
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void CreatureWithTripleBreakerBreaksThreeShields()
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(creature);
        var effect = new TripleBreakerEffect
        {
            Ability = ability.Object
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(3, actual);
    }
}