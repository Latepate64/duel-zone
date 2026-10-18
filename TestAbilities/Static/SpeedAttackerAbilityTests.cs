using Abilities.Static;
using Interfaces;
using Moq;

namespace TestAbilities.Static;

public class SpeedAttackerAbilityTests
{
    private static ISpeedAttackerAbility CreateAbility()
    {
        return new SpeedAttackerAbilityFactory().Create();
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var ability = CreateAbility();

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void CreatureWithoutSpeedAttackerCannotBlock()
    {
        // Arrange
        var ability = CreateAbility();
        var creatureWithoutSpeedAttacker = Mock.Of<ICreature>();

        // Act
        var actual = ability.Applies(creatureWithoutSpeedAttacker,
            Mock.Of<IGame>());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CreatureWithSpeedAttackerCanBlock()
    {
        // Arrange
        var speedAttacker = Mock.Of<ICreature>();
        var ability = CreateAbility();
        ability.Source = speedAttacker;

        // Act
        var actual = ability.Applies(speedAttacker, Mock.Of<IGame>());

        // Assert
        Assert.True(actual);
    }
}