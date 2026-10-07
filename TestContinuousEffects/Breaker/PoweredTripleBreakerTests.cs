using ContinuousEffects.Breaker;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.Breaker;

public class PoweredTripleBreakerEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new PoweredTripleBreaker();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void CreatureWithoutPoweredTripleBreakerBreaksOneShield()
    {
        // Arrange
        var effect = new PoweredTripleBreaker();
        var creature = Mock.Of<ICreature>();
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(1, actual);
    }

    [Theory]
    [InlineData(5999, 1)]
    [InlineData(14999, 2)]
    [InlineData(15000, 3)]
    public void CreatureBreaksShieldsBasedOnItsPower(int power, int shields)
    {
        // Arrange
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Power).Returns(power);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(creature.Object);
        var effect = new PoweredTripleBreaker
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