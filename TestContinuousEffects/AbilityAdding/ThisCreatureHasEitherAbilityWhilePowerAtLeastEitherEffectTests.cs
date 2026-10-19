using ContinuousEffects.AbilityAdding;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.AbilityAdding;

public class ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffectTests
{
    private static ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffect CreateEffect(
        int lowerGap, IAbility lowerAbility, int higherGap, IAbility higherAbility)
    {
        return new ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffectFactory().Create(
            lowerGap, lowerAbility, higherGap, higherAbility
        );
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = CreateEffect(6000, Mock.Of<IAbility>(), 15000, Mock.Of<IAbility>());

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void CreatureWithPowerLessThanBothRequirementsGetsNothing()
    {
        // Arrange
        var source = CreateCreature(5999);
        var lowerAbility = Mock.Of<IAbility>();
        var higherAbility = Mock.Of<IAbility>();
        var effect = CreateEffect(6000, lowerAbility, 15000, higherAbility);
        effect.Ability = CreateAbilityWithSource(source).Object;
        var game = new Mock<IGame>();

        // Act
        effect.AddAbility(game.Object);

        // Assert
        game.Verify(x => x.AddAbility(
            source.Object, lowerAbility), Times.Never);
        game.Verify(x => x.AddAbility(
            source.Object, higherAbility), Times.Never);
    }

    [Fact]
    public void CreatureWithPowerBetweenLowerAndHigherGapGetsLowerAbility()
    {
        // Arrange
        var source = CreateCreature(14999);
        var lowerAbility = Mock.Of<IAbility>();
        var higherAbility = Mock.Of<IAbility>();
        var effect = CreateEffect(6000, lowerAbility, 15000, higherAbility);
        effect.Ability = CreateAbilityWithSource(source).Object;
        var game = new Mock<IGame>();

        // Act
        effect.AddAbility(game.Object);

        // Assert
        game.Verify(x => x.AddAbility(
            source.Object, lowerAbility), Times.Once);
        game.Verify(x => x.AddAbility(
            source.Object, higherAbility), Times.Never);
    }

    [Fact]
    public void CreatureWithPowerAtLeastHigherGapGetsHigherAbility()
    {
        // Arrange
        var source = CreateCreature(15000);
        var lowerAbility = Mock.Of<IAbility>();
        var higherAbility = Mock.Of<IAbility>();
        var effect = CreateEffect(6000, lowerAbility, 15000, higherAbility);
        effect.Ability = CreateAbilityWithSource(source).Object;
        var game = new Mock<IGame>();

        // Act
        effect.AddAbility(game.Object);

        // Assert
        game.Verify(x => x.AddAbility(
            source.Object, lowerAbility), Times.Never);
        game.Verify(x => x.AddAbility(
            source.Object, higherAbility), Times.Once);
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