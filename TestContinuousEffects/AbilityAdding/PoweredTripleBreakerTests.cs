using Abilities.Static;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.AbilityAdding;

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
    public void CreatureWithPowerLessThan6000GetsNothing()
    {
        // Arrange
        var source = CreateCreature(5999);
        var effect = new PoweredTripleBreaker
        {
            Ability = CreateAbilityWithSource(source).Object
        };
        var game = new Mock<IGame>();

        // Act
        effect.AddAbility(game.Object);

        // Assert
        game.Verify(x => x.AddAbility(
            source.Object, It.IsAny<DoubleBreakerAbility>()), Times.Never);
        game.Verify(x => x.AddAbility(
            source.Object, It.IsAny<TripleBreakerAbility>()), Times.Never);
    }

    [Fact]
    public void CreatureWithPowerBetween6000And14999GetsDoubleBreaker()
    {
        // Arrange
        var source = CreateCreature(14999);
        var effect = new PoweredTripleBreaker
        {
            Ability = CreateAbilityWithSource(source).Object
        };
        var game = new Mock<IGame>();

        // Act
        effect.AddAbility(game.Object);

        // Assert
        game.Verify(x => x.AddAbility(
            source.Object, It.IsAny<DoubleBreakerAbility>()), Times.Once);
        game.Verify(x => x.AddAbility(
            source.Object, It.IsAny<TripleBreakerAbility>()), Times.Never);
    }

    [Fact]
    public void CreatureWithPowerAtLeast15000GetsDoubleBreaker()
    {
        // Arrange
        var source = CreateCreature(15000);
        var effect = new PoweredTripleBreaker
        {
            Ability = CreateAbilityWithSource(source).Object
        };
        var game = new Mock<IGame>();

        // Act
        effect.AddAbility(game.Object);

        // Assert
        game.Verify(x => x.AddAbility(
            source.Object, It.IsAny<DoubleBreakerAbility>()), Times.Never);
        game.Verify(x => x.AddAbility(
            source.Object, It.IsAny<TripleBreakerAbility>()), Times.Once);
    }

    static Mock<ICreature> CreateCreature(int power)
    {
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Power).Returns(power);
        return creature;
    }

    static Mock<IAbility> CreateAbilityWithSource(Mock<ICreature> source)
    {
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(source.Object);
        return ability;
    }
}