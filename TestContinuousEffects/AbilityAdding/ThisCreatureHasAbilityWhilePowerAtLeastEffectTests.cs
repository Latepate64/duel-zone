using ContinuousEffects.AbilityAdding;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.AbilityAdding;

public class ThisCreatureHasAbilityWhilePowerAtLeastEffectTests
{
    private static ThisCreatureHasAbilityWhilePowerAtLeastEffect CreateEffect(
        IAbility ability, int power)
    {
        return new ThisCreatureHasAbilityWhilePowerAtLeastEffectFactory().Create(power, ability);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = CreateEffect(Mock.Of<IAbility>(), 6000);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void CreatureWithPowerLessThanRequiredDoesNotGetAbility()
    {
        // Arrange
        var source = CreateCreature(5999);
        var ability = Mock.Of<IAbility>();
        var effect = CreateEffect(ability, 6000);
        effect.Ability = CreateAbilityWithSource(source).Object;
        var game = new Mock<IGame>();

        // Act
        effect.AddAbility(game.Object);

        // Assert
        game.Verify(x => x.AddAbility(source.Object, ability), Times.Never);
    }

    [Fact]
    public void CreatureWithPowerAtLeastRequiredGetsAbility()
    {
        // Arrange
        var source = CreateCreature(6000);
        var ability = Mock.Of<IAbility>();
        var effect = CreateEffect(ability, 6000);
        effect.Ability = CreateAbilityWithSource(source).Object;
        var game = new Mock<IGame>();

        // Act
        effect.AddAbility(game.Object);

        // Assert
        game.Verify(x => x.AddAbility(source.Object, ability), Times.Once);
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