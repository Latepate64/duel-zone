using Abilities.Static;
using Interfaces;
using Moq;

namespace TestAbilities.Static;

public class SpeedAttackerAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var ability = new SpeedAttackerAbility();

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void CreatureWithoutSpeedAttackerCannotBlock()
    {
        // Arrange
        var ability = new SpeedAttackerAbility();
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
        var ability = new SpeedAttackerAbility { Source = speedAttacker };

        // Act
        var actual = ability.Applies(speedAttacker, Mock.Of<IGame>());

        // Assert
        Assert.True(actual);
    }
}