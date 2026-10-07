using ContinuousEffects.Breaker;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.Breaker;

public class PoweredDoubleBreakerEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new PoweredDoubleBreaker();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void CreatureWithoutPoweredDoubleBreakerBreaksOneShield()
    {
        // Arrange
        var effect = new PoweredDoubleBreaker();
        var creature = Mock.Of<ICreature>();
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(1, actual);
    }

    [Theory]
    [InlineData(5999, 1)]
    [InlineData(6000, 2)]
    public void CreatureBreaksShieldsBasedOnItsPower(int power, int shields)
    {
        // Arrange
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Power).Returns(power);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(creature.Object);
        var effect = new PoweredDoubleBreaker
        {
            Ability = ability.Object
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.GetAmount(creature.Object, battleZone);

        // Assert
        Assert.Equal(shields, actual);
    }
}