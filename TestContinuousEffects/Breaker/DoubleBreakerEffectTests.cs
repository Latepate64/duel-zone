using ContinuousEffects.Breaker;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.Breaker;

public class DoubleBreakerEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new DoubleBreakerEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void CreatureWithoutDoubleBreakerBreaksOneShield()
    {
        // Arrange
        var effect = new DoubleBreakerEffect();
        var creature = Mock.Of<ICreature>();
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void CreatureWithDoubleBreakerBreaksTwoShields()
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(creature);
        var effect = new DoubleBreakerEffect
        {
            Ability = ability.Object
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(2, actual);
    }
}